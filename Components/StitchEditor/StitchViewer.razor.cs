using InCaseIForgetMyCrochet.Models;
using Microsoft.AspNetCore.Components;

namespace InCaseIForgetMyCrochet.Components.StitchEditor;
public partial class StitchViewer
{
    [Parameter] public Pattern? Pattern { get; set; }

    [Parameter] public int StitchAmount { private get; set; }

    [Parameter] public StitchTypeAbbreviation StitchType { private get; set; }

}
