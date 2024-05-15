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
}
