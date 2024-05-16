using InCaseIForgetMyCrochet.Models;
using Microsoft.AspNetCore.Components;

namespace InCaseIForgetMyCrochet.Components.StitchEditor;

public partial class StitchViewer
{
    [Parameter] public Pattern? Pattern { get; set; }
    [Parameter] public EventCallback Refresh { get; set; }
    [Parameter] public int StitchAmount { get; set; } = 1;
    [Parameter] public StitchTypeAbbreviation StitchType { get; set; }

    PatternDbContext Context { get; set; } = new PatternDbContext();

    async Task RemoveRow(Row row)
    {
        if (Pattern is null) return;
        Pattern.Rows.Remove(row);
        await Pattern.SaveChangesAsync(Context);
    }

    async Task AddStitchBundle(Row row)
    {
        if (Pattern is null) return;

        row.Instructions
        .AddRange(
            Enumerable
            .Range(0, StitchAmount)
            .Select(_ => new Instruction { StitchType = StitchType })
            );

        await Pattern.SaveChangesAsync(Context);
    }

    private async void SortList((int oldIndex, int newIndex) indices, IEnumerable<Instruction> instructions)
    {
        if (Pattern is null) return;
        var (oldIndex, newIndex) = indices;

        var items = instructions.ToList();
        var itemToMove = items[oldIndex];
        items.RemoveAt(oldIndex);

        if (newIndex < items.Count)
        {
            items.Insert(newIndex, itemToMove);
        }
        else
        {
            items.Add(itemToMove);
        }

        await Pattern.SaveChangesAsync(Context);
        StateHasChanged();
    }
}
