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
        _draggingCard = card;

        cardsParent.transform.parent = card.transform.root;

        card.transform.SetParent(card.transform.root);
        card.transform.SetAsLastSibling();

        card.GetComponent<Image>().raycastTarget = false;
    } 

    public void OnDragCard(PointerEventData eventData, CardView card)
    {
        card.transform.position = eventData.position;
    }

    public void OnEndDragCard(PointerEventData eventData, CardView card)
    {
        card.GetComponent<Image>().raycastTarget = true;

        if (_draggingCard == null)
            return;

        if (_draggingCard.CardModel.deck == card.CardModel.deck)
            _decksController?.InsertIntoDeck(card.CardModel.deck, card);

        _draggingCard = null;

    }    

    public void OnDropCardInDeck(IDeck deck, PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<CardView>(out var cardView))
        {
            if (deck.TryInsertCard(cardView))
            {
                _decksController?.InsertIntoDeck(deck, cardView);
                _draggingCard = null;
            }            
        }          
    }
}

