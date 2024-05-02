using UnityEngine.EventSystems;

public interface IGameDeckListener
{
    void OnDropCardInDeck(IPile deck, PointerEventData eventData);
}
public interface IDeliveryDeckListener
{
    void OnCroupierClick(PointerEventData eventData, CardView card);
}

public interface IDecksListener : IGameDeckListener, IDeliveryDeckListener
{

}

