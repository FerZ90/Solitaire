using UnityEngine;
using UnityEngine.EventSystems;

public class UserInputHandler : IObservable<UserInputHandlerObserverModel>, IObserver<CardViewObserverModel>, IObserver<CardsObjectCreatorObserverModel>
{
    private CardView _draggingCard;
    private GameObject _cardsParent;

    public Observer<UserInputHandlerObserverModel> Observer { get; set; } = new();

    public UserInputHandler(IObservable<CardsObjectCreatorObserverModel> observable, GameObject cardsParent)
    {
        _cardsParent = cardsParent;
        observable.Observer.Subscribe(this);
    }

    public void UpdateEvent(CardsObjectCreatorObserverModel parameter)
    {
        foreach (var card in parameter.cardsViews)
            card.Observer.Subscribe(this);
    }

    public void UpdateEvent(CardViewObserverModel parameter)
    {
        switch (parameter.inputState)
        {
            case CardInputState.OnBeginDrag:
                OnBeginDragCard(parameter.card);
                break;
            case CardInputState.OnDrag:
                OnDragCard(parameter.eventData, parameter.card);
                break;
            case CardInputState.OnEndDrag:
                OnEndDragCard(parameter.eventData, parameter.card);
                break;
            default:
                break;
        }
    }

    private void OnBeginDragCard(CardView card)
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

    private void OnDragCard(PointerEventData eventData, CardView card)
    {
        if (card.CardModel.deck == null || card.Reverse)
            return;

        _cardsParent.transform.position = eventData.position;
    }

    private void OnEndDragCard(PointerEventData eventData, CardView card)
    {
        Debug.Log("OnEndDragCard_00");
        if (card.CardModel.deck == null || card.Reverse)
            return;

        var nodeCards = card.CardModel.deck.GetNodeCards(card);

        Debug.Log("OnEndDragCard_01");

        if (_draggingCard == null)
            return;

        Debug.Log("OnEndDragCard_02");

        foreach (var nodeCard in nodeCards)
        {
            Debug.Log("OnEndDragCard_03");
            if (_draggingCard.CardModel.deck == nodeCard.CardModel.deck)
                Observer.Notify(new UserInputHandlerObserverModel(nodeCard.CardModel.deck, nodeCard));
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
                    Observer.Notify(new UserInputHandlerObserverModel(deck, nodeCard));
                else
                    Observer.Notify(new UserInputHandlerObserverModel(nodeCard.CardModel.deck, nodeCard));
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

        Observer.Notify(new UserInputHandlerObserverModel(null, card));
    }
}




