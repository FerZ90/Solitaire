using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICardsObjectCreatorListener
{
    public bool BlockUserInput { get; private set; }

    private IUserDecksController _decksController; 

    public Croupier(IUserDecksController deckController)
    {      
        _decksController = deckController;
        BlockUserInput = false;
    }

    public void InsertIntoCroupierDeck(CardView cardView)
    {
        var croupierDeck = _decksController.DeckModel.deliveryDeck;
        croupierDeck.AddLast(cardView);
    }

    public void InsertIntoDiscardDeck(CardView cardView)
    {
        //throw new System.NotImplementedException();
    }

    public async void DealCards()
    {
        int count = 1;

        foreach (var inGameDeck in _decksController.DeckModel.inGameDecks)
        {
            for (int i = 0; i < count; i++)
            {
                var card = _decksController.DeckModel.deliveryDeck.RemoveLast();

                if (card != null)
                {
                    if (i == count - 1)
                       card.SetReverse(false);

                    _decksController.InsertIntoDeck(inGameDeck, card);
                }
                else
                {
                    Debug.LogError("DeliveryDeck is empty !!");
                }              

                await Task.Delay(100);
            }

            count++;
        }

        BlockUserInput = true;
    }

    public async void OnCreateCardsViews(List<CardView> cardViews)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in cardViews)
        {
            InsertIntoCroupierDeck(cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        DealCards();
    }

}

