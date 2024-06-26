using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserInputHandler : ICardViewListener, IDropPileListener, ICardsObjectCreatorListener
{
    private CardView _draggingCard;
    private GameObject _cardsParent;
    private IUserInputHandlerListener _listener;

    public UserInputHandler(IUserInputHandlerListener listener, GameObject cardsParent)
    {
        _listener = listener;
        _cardsParent = cardsParent;
    }

    public void OnCreateCards(List<CardView> cardsViews)
    {
        foreach (var card in cardsViews)
            card.Setup(this);
    }

    public void OnBeginDrag(CardView card, PointerEventData eventData)
    {
        if (card.CardModel.deck == null || card.Reverse)
            return;

        _cardsParent.transform.position = card.transform.position;

        var nodeCards = card.CardModel.deck.GetNodeCards(card);

        foreach (var nodeCard in nodeCards)
        {
            nodeCard.transform.SetParent(_cardsParent.transform);
            nodeCard.transform.SetAsLastSibling();
        }

        _draggingCard = card;

    }

    public void OnDrag(CardView card, PointerEventData eventData)
    {
        if (card.CardModel.deck == null || card.Reverse)
            return;

        _cardsParent.transform.position = eventData.position;
    }

    public void OnEndDrag(CardView card, PointerEventData eventData)
    {
        if (card.CardModel.deck == null || card.Reverse)
            return;

        var nodeCards = card.CardModel.deck.GetNodeCards(card);

        if (_draggingCard == null)
            return;

        foreach (var nodeCard in nodeCards)
        {
            if (_draggingCard.CardModel.deck == nodeCard.CardModel.deck)
                _listener.OnEndDragCard(nodeCard.CardModel.deck, nodeCard, MovementType.User);
        }

        _draggingCard = null;

    }

    public void OnDropCardInDeck(IPile deck, PointerEventData eventData, MovementType movementType)
    {
        if (eventData.pointerDrag.TryGetComponent<CardView>(out var cardView))
        {
            if (cardView.CardModel.deck == null)
                return;

            var nodeCards = cardView.CardModel.deck.GetNodeCards(cardView);

            var canInsertCards = deck.TryInsertCard(cardView);

            foreach (var nodeCard in nodeCards)
            {
                if (canInsertCards)
                    _listener.OnDropCard(deck, nodeCard, movementType);
                else
                    _listener.OnDropCard(nodeCard.CardModel.deck, nodeCard, movementType);
            }

            _draggingCard = null;

        }
    }

}

public interface IUserInputHandlerListener
{
    void OnEndDragCard(IPile pile, CardView card, MovementType movementType);
    void OnDropCard(IPile pile, CardView card, MovementType movementType);
}






