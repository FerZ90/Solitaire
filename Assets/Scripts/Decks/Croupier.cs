using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICroupier, IObserver<CardsObjectCreatorObserverModel>, IObserver<CardMovementObserverModel>
{
    private DeckModel _deckModel;
    private ICardTranslator _cardTranslator;

    public Croupier(DeckModel deckModel, IObservable<CardsObjectCreatorObserverModel> cardsCreatorObservable, IObservable<CardMovementObserverModel> cardMovementObserverModel, ICardTranslator cardTranslator)
    {
        _deckModel = deckModel;
        cardsCreatorObservable.Observer.Subscribe(this);
        cardMovementObserverModel.Observer.Subscribe(this);
        _cardTranslator = cardTranslator;
    }

    public async void DealCards()
    {
        int count = 1;

        foreach (var inGameDeck in _deckModel.inGameDecks)
        {
            for (int i = 0; i < count; i++)
            {
                var card = _deckModel.deliveryDeck.GetLast();

                if (card != null)
                {
                    if (i == count - 1)
                        card.SetReverse(false);

                    _cardTranslator.MoveCard(inGameDeck, card);
                }
                else
                {
                    Debug.LogError("DeliveryDeck is empty !!");
                }

                await Task.Delay(100);
            }

            count++;
        }

    }

    public void UpdateEvent(CardMovementObserverModel parameter)
    {
        if (parameter.deck is DeliveryDeck)
        {
            DeliverCard(parameter.card);
        }
        else if ()
        {
            _cardTranslator.MoveCard(parameter.deck, parameter.card);
        }
    }


    public async void UpdateEvent(CardsObjectCreatorObserverModel parameter)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in parameter.cardsViews)
        {
            _cardTranslator.MoveCard(_deckModel.deliveryDeck, cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        DealCards();
    }


    public async void DeliverCard(CardView cardView)
    {
        if (cardView == null)
        {
            var lastCard = _deckModel.discardDeck.GetLast();

            while (lastCard != null)
            {
                _cardTranslator.MoveCard(_deckModel.deliveryDeck, lastCard);
                lastCard = _deckModel.discardDeck.GetLast();
                await Task.Delay(7);
            }
        }
        else
        {
            _cardTranslator.MoveCard(_deckModel.discardDeck, cardView);
        }
    }

}


