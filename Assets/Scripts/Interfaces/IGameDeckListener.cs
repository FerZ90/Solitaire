using UnityEngine.EventSystems;

public interface IGameDeckListener
{
    public void OnDropCardInDeck(IDeck deck, PointerEventData eventData);
}

public interface IDecksListener : IGameDeckListener, IDeliveryDeckListener
{

}

