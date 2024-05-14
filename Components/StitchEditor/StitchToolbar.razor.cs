using InCaseIForgetMyCrochet.Models;
using Microsoft.AspNetCore.Components;

namespace InCaseIForgetMyCrochet.Components.StitchEditor;

public partial class StitchToolbar
{
    [Parameter] public Pattern? Pattern { get; set; }
    [Parameter] public EventCallback Refresh { get; set; }
    [Parameter] public EventCallback<int> StitchAmountChanged { get; set; }
    [Parameter] public EventCallback<StitchTypeAbbreviation> StitchTypeChanged { get; set; }

    int _StitchAmount;
    int StitchAmount
    {
        get => _StitchAmount;
        set
        {
            _StitchAmount = value;
            StitchAmountChanged.InvokeAsync(value);
        }
    }
    StitchTypeAbbreviation _StitchType;
    StitchTypeAbbreviation StitchType
    {
        get => _StitchType;
        set
        {
            _StitchType = value;
            StitchTypeChanged.InvokeAsync(value);
        }
    }
}
