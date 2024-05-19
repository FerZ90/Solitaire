using UnityEngine.EventSystems;

public class DropPile : Pile, IDropHandler
{
    private IDropPileListener _listener;

    public void Setup(IDropPileListener listener)
    {
        _listener = listener;
    }

    public void OnDrop(PointerEventData eventData)
    {
        _listener.OnDropCardInDeck(this, eventData, MovementType.User);
    }
}

public interface IDropPileListener
{
    void OnDropCardInDeck(IPile pile, PointerEventData eventData, MovementType movementType);
}
