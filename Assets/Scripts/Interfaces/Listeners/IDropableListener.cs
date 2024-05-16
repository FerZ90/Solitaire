using UnityEngine.EventSystems;

public interface IDropableListener
{
    void OnDropCardInDeck(IPile deck, PointerEventData eventData);
}
public interface IDeliveryDeckListener
{
    void OnCroupierClick(CardView card);
}

public interface IDecksListener : IDropableListener, IDeliveryDeckListener
{

}



