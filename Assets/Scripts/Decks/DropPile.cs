using UnityEngine.EventSystems;

public class DropPile : Pile, IDropHandler
{
    protected IDropableListener _listener;

    public void Setup(IDropableListener listener)
    {
        _listener = listener;
    }

    public void OnDrop(PointerEventData eventData)
    {
        _listener?.OnDropCardInDeck(this, eventData);
    }
}
