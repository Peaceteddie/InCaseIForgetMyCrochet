using InCaseIForgetMyCrochet.Models;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace InCaseIForgetMyCrochet.Components.StitchEditor;

public partial class StitchViewer
{
    [Parameter] public Pattern? Pattern { get; set; }
    [Parameter] public int StitchAmount { get; set; } = 1;
    [Parameter] public StitchTypeAbbreviation StitchType { get; set; }
    [Parameter] public bool FromToolbar { get; set; } = false;
    [Inject] PatternDbContext Context { get; set; } = default!;
    
    static readonly int amountOfStitchTypes = Enum.GetValues(typeof(StitchTypeAbbreviation)).Length;
    static readonly SemaphoreSlim saveLock = new(1, 1);

    static IEnumerable<StitchTypeAbbreviation> StitchTypes
    => Enum.GetValues(typeof(StitchTypeAbbreviation)).Cast<StitchTypeAbbreviation>();
    static IEnumerable<(StitchTypeAbbreviation, int)> StitchTypesWithIndex
    => StitchTypes.Select((type, index) => (type, index));
    static string GetButtonStyle(int index, int totalButtons)
    {
        double angle = 2 * Math.PI * index / totalButtons;
        double radius = 100;
        double x = radius * Math.Cos(angle);
        double y = radius * Math.Sin(angle);
        return $"position:absolute; left:calc(50% + {x.ToString(CultureInfo.InvariantCulture)}px); top:calc(50% - {y.ToString(CultureInfo.InvariantCulture)}px); transform:translate(-50%, -50%);z-index:{10 + index};";
    }

    Instruction? selectedInstruction;
    StitchTypeAbbreviation? LastType;

    Instruction CreateInstruction(int index)
            => new() { Index = index, StitchType = StitchType };

    async Task AddStitchBundle(Row row)
    {
        if (Pattern is null) return;
        var nextIndex = row.Instructions.Count;
        row.Instructions.AddRange(Enumerable.Range(0, StitchAmount).Select(_ => CreateInstruction(nextIndex++)));
        await SaveSafely();
    }
    async Task ChangeStitchType(StitchTypeAbbreviation newType, Instruction instruction)
    {
        if (Pattern is null) return;
        instruction.StitchType = newType;
        selectedInstruction = null;
        await SaveSafely();
    }
    async Task InsertInstruction(Row row, int newIndex, StitchTypeAbbreviation type)
    {
        if (Pattern is null) return;

        Pattern.Rows[row.Index].Instructions
        .Insert(newIndex, new Instruction { Index = newIndex, StitchType = type });

        await SaveSafely();
    }
    async Task RemoveInstruction(Row row, int oldIndex, string? targetID = null)
    {
        if (Pattern is null) return;
        if (targetID == "TOOLBAR") return;
        LastType = Pattern.Rows[row.Index].Instructions[oldIndex].StitchType;
        Pattern.Rows[row.Index].Instructions.RemoveAt(oldIndex);

        await SaveSafely();
    }
    async Task RemoveRow(Row row)
    {
        if (Pattern is null) return;
        Pattern.Rows.Remove(row);
        await SaveSafely();
    }
    async Task SaveSafely()
    {
        Pattern!.Rows.ForEach(r =>
        {
            r.Instructions.ForEach(i => i.Index = r.Instructions.IndexOf(i));
            r.Index = Pattern.Rows.IndexOf(r);
        });

        await saveLock.WaitAsync();
        try
        {
            await Pattern!.SaveChangesAsync(Context);
        }
        finally
        {
            saveLock.Release();
        }
    }
    async Task UpdateInstruction(Row row, int oldIndex, int newIndex)
    {
        if (Pattern is null) return;
        var instruction = Pattern.Rows[row.Index].Instructions[oldIndex];
        Pattern.Rows[row.Index].Instructions.Insert(newIndex, instruction);
        Pattern.Rows[row.Index].Instructions.RemoveAt(oldIndex < newIndex ? oldIndex : oldIndex + 1);
        await SaveSafely();
    }
}
