using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICardsObjectCreatorListener, ICroupier
{
    public bool BlockUserInput { get; private set; }

    private IUserDecksController _decksController; 

    public Croupier(IUserDecksController deckController)
    {      
        _decksController = deckController;
        BlockUserInput = false;
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
            _decksController.InsertIntoCroupierDeck(cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        DealCards();
    }
   
    public void InsertIntoDeck(IDeck deck, CardView cardView)
    {
        switch (deck)
        {
            case null:
                Debug.LogError("Trying to insert card into null deck !!");
                break;
            case InGameDeck:
                _decksController.InsertIntoDeck(deck, cardView);
                break;
            case FinishedDeck:
                _decksController.InsertIntoFinishedDeck(cardView);
                break;
            case DeliveryDeck:
                _decksController.InsertIntoCroupierDeck(cardView);
                break;
            case DiscardDeck:
                _decksController.InsertIntoDiscardDeck(cardView);
                break;
            default:
                break;
        }
    }

    public void DeliverCard(CardView cardView)
    {
        _decksController.InsertIntoDiscardDeck(cardView);
    }
}

public interface ICroupier
{
    void InsertIntoDeck(IDeck deck, CardView cardView);
    void DeliverCard(CardView cardView);
}

