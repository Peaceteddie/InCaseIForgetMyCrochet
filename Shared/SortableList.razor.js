export function init(
  id,
  group,
  pull,
  put,
  sort,
  handle,
  filter,
  component,
  forceFallback
) {
  var sortable = new Sortable(document.getElementById(id), {
    animation: 200,
    group: {
      name: group,
      pull: pull || true,
      put: put,
    },
    filter: filter || undefined,
    sort: sort,
    forceFallback: forceFallback,
    handle: handle || undefined,
    onAdd: (event) => {
      event.item.remove();
      component.invokeMethodAsync(
        "OnAddJS",
        event.oldDraggableIndex,
        event.newDraggableIndex,
        event.item.textContent.trim()
      );
    },
    onUpdate: (event) => {
      event.item.remove();
      event.to.insertBefore(event.item, event.to.childNodes[event.oldIndex]);
      component.invokeMethodAsync(
        "OnUpdateJS",
        event.oldDraggableIndex,
        event.newDraggableIndex
      );
    },
    onRemove: (event) => {
      if (event.pullMode === "clone") {
        event.clone.remove();
      }
      event.item.remove();
      event.from.insertBefore(
        event.item,
        event.from.childNodes[event.oldIndex]
      );
      component.invokeMethodAsync(
        "OnRemoveJS",
        event.oldDraggableIndex,
        event.newDraggableIndex
      );
    },
  });
}
