using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserInputHandler : ICardInputHandlerListener, IDecksListener, IObserver<List<CardView>>, IObserver<CardviewObserverModel>
{
    private ICroupier _croupier;
    private CardView _draggingCard;
    private GameObject _cardsParent;

    public UserInputHandler(ICardsObjectCreator cardsCreator, ICroupier croupier, GameObject cardsParent)
    {
        _croupier = croupier;
        _cardsParent = cardsParent;
        cardsCreator.CardsObjectCreatorObserver.Subscribe(this);
    }

    public void UpdateEvent(List<CardView> parameter)
    {
        foreach (var cardview in parameter)
            cardview.CardviewObserver.Subscribe(this);
      
    }

    public void UpdateEvent(CardviewObserverModel parameter)
    {
        switch (parameter.eventType) 
        {
            case CardViewEventType.OnBeginDrag:
                OnBeginDragCard(parameter.eventData, parameter.card);
                break;        
            case CardViewEventType.OnDrag:
                OnDragCard(parameter.eventData, parameter.card);
                break;
            case CardViewEventType.OnEndDrag:
                OnEndDragCard(parameter.eventData, parameter.card);
                break;
        }
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
                _croupier?.InsertIntoDeck(nodeCard.CardModel.deck, nodeCard);
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
                    _croupier?.InsertIntoDeck(deck, nodeCard);
                else
                    _croupier?.InsertIntoDeck(nodeCard.CardModel.deck, nodeCard);
            }

            _draggingCard = null;

        }          
    }

    public void OnCroupierClick(PointerEventData eventData, CardView card)
    {
        if (card != null)
        {
            card.transform.SetParent(_cardsParent.transform);
            card.transform.SetAsLastSibling();
        }      

        _croupier?.DeliverCard(card);
    } 
}



