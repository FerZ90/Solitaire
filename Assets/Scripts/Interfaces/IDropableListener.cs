using UnityEngine.EventSystems;

public interface IDropableListener
{
    void OnDropCardInDeck(IPile deck, PointerEventData eventData);
}
public interface IDeliveryDeckListener
{
    void OnCroupierClick(PointerEventData eventData, CardView card);
}

public interface IDecksListener : IDropableListener, IDeliveryDeckListener
{

}

