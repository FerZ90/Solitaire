using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserInputHandler : ICardInputHandlerListener, IDeckInputHandlerListener
{
    private IDecksController _decksController;
    private CardView _draggingCard;
    private GameObject cardsParent = new GameObject("CardsParent");

    public UserInputHandler(IDecksController decksController)
    {
        _decksController = decksController;
    }  

    public void OnBeginDragCard(PointerEventData eventData, CardView card)
    {
        cardsParent.transform.parent = card.transform.root;
        cardsParent.transform.position = card.transform.position;

        var nodeCards = card.CardModel.deck.GetNodeCards(card);

        foreach (var nodeCard in nodeCards)
        {
            nodeCard.transform.SetParent(cardsParent.transform);
            nodeCard.transform.SetAsLastSibling();
            nodeCard.GetComponent<Image>().raycastTarget = false;
        }

        _draggingCard = card;

    } 

    public void OnDragCard(PointerEventData eventData, CardView card)
    {
        cardsParent.transform.position = eventData.position;       
    }

    public void OnEndDragCard(PointerEventData eventData, CardView card)
    {
        if (_draggingCard == null)
            return;

        var nodeCards = card.CardModel.deck.GetNodeCards(card);

        foreach (var nodeCard in nodeCards)
        {
            nodeCard.GetComponent<Image>().raycastTarget = true;
            if (nodeCard.CardModel.deck == nodeCard.CardModel.deck)
                _decksController?.InsertIntoDeck(nodeCard.CardModel.deck, nodeCard);
        }         

    }    

    public void OnDropCardInDeck(IDeck deck, PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<CardView>(out var cardView))
        {
            var nodeCards = cardView.CardModel.deck.GetNodeCards(cardView);

            foreach (var nodeCard in nodeCards)
            {
                nodeCard.GetComponent<Image>().raycastTarget = true;

                if (deck.TryInsertCard(cardView))
                {
                    _decksController?.InsertIntoDeck(deck, nodeCard);
                    _draggingCard = null;
                }
            }
                     
        }          
    }
}



