using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICroupier, IObserver<CardsObjectCreatorObserverModel>, IObserver<UserInputHandlerObserverModel>
{
    private CroupierSetupModel _model;

    public Croupier(CroupierSetupModel model)
    {
        _model = model;
        _model.cardsCreatorObservable.Observer.Subscribe(this);
        _model.inputHandlerObservable.Observer.Subscribe(this);
    }

    public async void DealCards()
    {
        int count = 1;

        foreach (var inGameDeck in _model.deckModel.inGameDecks)
        {
            for (int i = 0; i < count; i++)
            {
                var card = _model.deckModel.deliveryDeck.GetLast();

                if (card != null)
                {
                    if (i == count - 1)
                        card.SetReverse(false);

                    _model.cardTranslator.MoveCard(inGameDeck, card);
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

    public void UpdateEvent(UserInputHandlerObserverModel parameter)
    {
        _model.cardTranslator.MoveCard(parameter.pile, parameter.card);
    }


    public async void UpdateEvent(CardsObjectCreatorObserverModel parameter)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in parameter.cardsViews)
        {
            _model.cardTranslator.MoveCard(_model.deckModel.deliveryDeck, cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        DealCards();
    }


    public async void DeliverCard(CardView cardView)
    {
        if (cardView == null)
        {
            var lastCard = _model.deckModel.discardDeck.GetLast();

            while (lastCard != null)
            {
                _model.cardTranslator.MoveCard(_model.deckModel.deliveryDeck, lastCard);
                lastCard = _model.deckModel.discardDeck.GetLast();
                await Task.Delay(7);
            }
        }
        else
        {
            _model.cardTranslator.MoveCard(_model.deckModel.discardDeck, cardView);
        }
    }

}

public class CroupierSetupModel
{
    public DeckModel deckModel;
    public IObservable<CardsObjectCreatorObserverModel> cardsCreatorObservable;
    public IObservable<UserInputHandlerObserverModel> inputHandlerObservable;
    public ICardTranslator cardTranslator;

}

