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
}
