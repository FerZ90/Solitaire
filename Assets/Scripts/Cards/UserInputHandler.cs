using UnityEngine;
using UnityEngine.EventSystems;

public class UserInputHandler : ICardviewListener, IDecksListener
{
    private UserInputHandlerListener _listener;
    private CardView _draggingCard;
    private GameObject _cardsParent;

    public UserInputHandler(UserInputHandlerListener listener, GameObject cardsParent)
    {
        _listener = listener;
        _cardsParent = cardsParent;
    }

    public void OnBeginDragCard(PointerEventData eventData, CardView card)
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

    public void OnDragCard(PointerEventData eventData, CardView card)
    {
        if (card.CardModel.deck == null || card.Reverse)
            return;

        _cardsParent.transform.position = eventData.position;
    }

    public void OnEndDragCard(PointerEventData eventData, CardView card)
    {
        if (card.CardModel.deck == null || card.Reverse)
            return;

        var nodeCards = card.CardModel.deck.GetNodeCards(card);

        if (_draggingCard == null)
            return;

        foreach (var nodeCard in nodeCards)
        {
            if (_draggingCard.CardModel.deck == nodeCard.CardModel.deck)
                _listener?.InsertIntoDeck(nodeCard.CardModel.deck, nodeCard);
        }

        _draggingCard = null;

    }

    public void OnDropCardInDeck(IPile deck, PointerEventData eventData)
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
                    _listener?.InsertIntoDeck(deck, nodeCard);
                else
                    _listener?.InsertIntoDeck(nodeCard.CardModel.deck, nodeCard);
            }

            _draggingCard = null;

        }
    }

    public void OnCroupierClick(CardView card)
    {
        if (card != null)
        {
            card.transform.SetParent(_cardsParent.transform);
            card.transform.SetAsLastSibling();
        }

        _listener?.DeliverCard(card);
    }

}



