using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserInputHandler : ICardInputHandlerListener, IDeckInputHandlerListener
{
    private IDecksController _decksController;
    private CardView _draggingCard;
    private GameObject _cardsParent;

    public UserInputHandler(IDecksController decksController, GameObject cardsParent)
    {
        _decksController = decksController;
        _cardsParent = cardsParent;  
    }  

    public void OnBeginDragCard(PointerEventData eventData, CardView card)
    {    
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
        _cardsParent.transform.position = eventData.position;       
    }

    public void OnEndDragCard(PointerEventData eventData, CardView card)
    {
        var nodeCards = card.CardModel.deck.GetNodeCards(card);

        if (_draggingCard == null)
            return;

        foreach (var nodeCard in nodeCards)
        {
            if (_draggingCard.CardModel.deck == nodeCard.CardModel.deck)
                _decksController?.InsertIntoDeck(nodeCard.CardModel.deck, nodeCard);
        }

        _draggingCard = null;

    }    

    public void OnDropCardInDeck(IDeck deck, PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<CardView>(out var cardView))
        {
            var nodeCards = cardView.CardModel.deck.GetNodeCards(cardView);

            foreach (var nodeCard in nodeCards)
            {
                if (deck.TryInsertCard(cardView))
                    _decksController?.InsertIntoDeck(deck, nodeCard);
            }

            _draggingCard = null;

        }          
    }
}



