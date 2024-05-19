using InCaseIForgetMyCrochet.Models;
using Microsoft.AspNetCore.Components;

namespace InCaseIForgetMyCrochet.Components.StitchEditor;

public partial class StitchToolbar
{
    [Parameter] public Pattern? Pattern { get; set; }
    [Parameter] public EventCallback IJustDragged { get; set; }
    [Parameter] public EventCallback<(int?, StitchTypeAbbreviation?)> Refresh { get; set; }
    [Parameter] public int StitchAmount { get; set; }
    [Parameter] public StitchTypeAbbreviation StitchType { get; set; }
    [Inject] PatternDbContext Context { get; set; } = default!;

    async Task AddStitch(StitchTypeAbbreviation type)
    {
        if (Pattern is null) return;

        Pattern.Rows
        .FirstOrDefault()?
        .Instructions
        .Add(new Instruction { StitchType = type });

        await SaveAndRefresh();
    }
    async Task SaveAndRefresh()
    {
        if (Pattern is null) return;
        await Pattern.SaveChangesAsync(Context);
        await Refresh.InvokeAsync();
    }
}
