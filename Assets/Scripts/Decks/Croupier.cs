using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICroupier, IObserver<CardsObjectCreatorObserverModel>
{
    private DeckModel _deckModel;

    public Croupier(IObservable<CardsObjectCreatorObserverModel> observable, DeckModel deckModel)
    {
        _deckModel = deckModel;
        observable.Observer.Subscribe(this);
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

                    ChangeCardDeck(inGameDeck, card);
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


    public async void UpdateEvent(CardsObjectCreatorObserverModel parameter)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in parameter.cardsViews)
        {
            ChangeCardDeck(_deckModel.deliveryDeck, cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        DealCards();
    }



    public void InsertIntoDeck(IPile deck, CardView cardView)
    {
        ChangeCardDeck(deck, cardView);
    }

    public async void DeliverCard(CardView cardView)
    {
        if (cardView == null)
        {
            var lastCard = _deckModel.discardDeck.GetLast();

            while (lastCard != null)
            {
                ChangeCardDeck(_deckModel.deliveryDeck, lastCard);
                lastCard = _deckModel.discardDeck.GetLast();
                await Task.Delay(7);
            }
        }
        else
        {
            ChangeCardDeck(_deckModel.discardDeck, cardView);
        }
    }


    private void ChangeCardDeck(IPile newDeck, CardView cardView)
    {
        var newCardDeck = newDeck;

        if (newCardDeck == null)
            newCardDeck = cardView.CardModel.deck;

        cardView.CardModel.LogCard();

        if (cardView.CardModel.deck == newDeck)
        {
            cardView.CardModel.deck.ReturnCardToDeck(cardView);
        }
        else
        {

            if (cardView.CardModel.deck != null)
                cardView.CardModel.deck.RemoveLast();

            cardView.CardModel.deck = newCardDeck;
            cardView.CardModel.deck.AddLast(cardView);
        }
    }
}

