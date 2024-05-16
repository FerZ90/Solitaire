using UnityEngine.EventSystems;

public class DropPile : Pile, IDropHandler
{
    public Observer<DropPileObserverModel> Observer { get; set; } = new();

    public void OnDrop(PointerEventData eventData)
    {
        Observer.Notify(new DropPileObserverModel(this, eventData));
    }
}
