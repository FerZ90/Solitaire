using System.Collections.Generic;
using UnityEngine.EventSystems;

public interface IGameDeckListener
{
    void OnDeckComplete(List<CardView> deck);
    void OnDropCardInDeck(IDeck deck, PointerEventData eventData);
}

public interface IDecksListener : IGameDeckListener, IDeliveryDeckListener
{

}

