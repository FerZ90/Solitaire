using UnityEngine.EventSystems;

public class DropPile : Pile, IDropHandler
{
    public Observer<CardMovementObserverModel> Observer { get; set; } = new();

    public void OnDrop(PointerEventData eventData)
    {
        Observer.Notify(new CardMovementObserverModel(this, null, eventData));
    }
}
