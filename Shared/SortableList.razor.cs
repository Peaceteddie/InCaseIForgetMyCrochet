
using System.Diagnostics.CodeAnalysis;
using InCaseIForgetMyCrochet.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace InCaseIForgetMyCrochet.Shared;
public partial class SortableList<T> : ComponentBase, IDisposable
{
    [Inject] IJSRuntime JS { get; set; } = default!;

    [Parameter] public RenderFragment<T>? SortableItemTemplate { get; set; }
    [Parameter, AllowNull] public List<T> Items { get; set; }
    [Parameter] public EventCallback<(int oldIndex, int newIndex, StitchTypeAbbreviation type)> OnAdd { get; set; }
    [Parameter] public EventCallback<(int oldIndex, int newIndex)> OnRemove { get; set; }
    [Parameter] public EventCallback<(int oldIndex, int newIndex)> OnUpdate { get; set; }
    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Parameter] public string Group { get; set; } = Guid.NewGuid().ToString();
    [Parameter] public string? Pull { get; set; }
    [Parameter] public bool Put { get; set; } = true;
    [Parameter] public bool Sort { get; set; } = true;
    [Parameter] public string Handle { get; set; } = string.Empty;
    [Parameter] public string? Filter { get; set; }
    [Parameter] public bool ForceFallback { get; set; } = true;
    private DotNetObjectReference<SortableList<T>>? selfReference;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            selfReference = DotNetObjectReference.Create(this);
            var module = await JS.InvokeAsync<IJSObjectReference>("import", "./Shared/SortableList.razor.js");
            await module.InvokeAsync<string>("init", Id, Group, Pull, Put, Sort, Handle, Filter, selfReference, ForceFallback);
        }
    }
    [JSInvokable]
    public void OnAddJS(int oldIndex, int newIndex, string type)
    {
        if (Enum.TryParse(type.Trim(), out StitchTypeAbbreviation stitch))
            OnAdd.InvokeAsync((oldIndex, newIndex, stitch));
        else
            OnAdd.InvokeAsync((oldIndex, newIndex, default));
    }
    [JSInvokable]
    public void OnRemoveJS(int oldIndex, int newIndex)
    {
        OnRemove.InvokeAsync((oldIndex, newIndex));
    }
    [JSInvokable]
    public void OnUpdateJS(int oldIndex, int newIndex)
    {
        OnUpdate.InvokeAsync((oldIndex, newIndex));
    }
    public void Dispose()
    {
        selfReference?.Dispose();
    }
}