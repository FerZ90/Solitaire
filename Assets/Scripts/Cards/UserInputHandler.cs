using UnityEngine;
using UnityEngine.EventSystems;

public class UserInputHandler : ICardInputHandlerListener, IDeckInputHandlerListener
{
    private ICroupier _croupier;
    private CardView _draggingCard;
    private GameObject _cardsParent;

    public UserInputHandler(ICroupier croupier, GameObject cardsParent)
    {
        _croupier = croupier;
        _cardsParent = cardsParent;  
    }  

    public void OnBeginDragCard(PointerEventData eventData, CardView card)
    {
        if (card.CardModel.deck == null || !card.CardModel.deck.IsValidDragging(card))
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
        if (card.CardModel.deck == null || !card.CardModel.deck.IsValidDragging(card))
            return;

        _cardsParent.transform.position = eventData.position;       
    }

    public void OnEndDragCard(PointerEventData eventData, CardView card)
    {
        if (card.CardModel.deck == null || !card.CardModel.deck.IsValidDragging(card))
            return;

        var nodeCards = card.CardModel.deck.GetNodeCards(card);

        if (_draggingCard == null)
            return;

        foreach (var nodeCard in nodeCards)
        {
            if (_draggingCard.CardModel.deck == nodeCard.CardModel.deck)
                _croupier?.InsertIntoDeck(nodeCard.CardModel.deck, nodeCard);
        }

        _draggingCard = null;

    }    

    public void OnDropCardInDeck(IDeck deck, PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<CardView>(out var cardView))
        {
            var nodeCards = cardView.CardModel.deck.GetNodeCards(cardView);

            var canInsertCards = deck.TryInsertCard(cardView);

            foreach (var nodeCard in nodeCards)
            {
                if (canInsertCards)
                    _croupier?.InsertIntoDeck(deck, nodeCard);
                else
                    _croupier?.InsertIntoDeck(nodeCard.CardModel.deck, nodeCard);
            }

            _draggingCard = null;

        }          
    }

    public void OnCroupierClick(PointerEventData eventData, CardView card)
    {
        _croupier?.DeliverCard(card);
    }
}



