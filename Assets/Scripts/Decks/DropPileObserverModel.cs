using UnityEngine.EventSystems;

public struct DropPileObserverModel
{
    public IPile deck;
    public PointerEventData eventData;

    public DropPileObserverModel(IPile deck, PointerEventData eventData)
    {
        this.deck = deck;
        this.eventData = eventData;
    }
}
