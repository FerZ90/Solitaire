using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICardsObjectCreatorListener, ICroupier
{
    private DeckModel _deckModel; 

    public Croupier(DeckModel deckModel)
    {
        _deckModel = deckModel;        
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
            
                    UserDecksController.InsertIntoDeck(inGameDeck, card);
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

    public async void OnCreateCardsViews(List<CardView> cardViews)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in cardViews)
        {
            UserDecksController.InsertIntoDeck(_deckModel.deliveryDeck, cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        DealCards();
    }
   
    public void InsertIntoDeck(IDeck deck, CardView cardView)
    {
        UserDecksController.InsertIntoDeck(deck, cardView);      
    }

    public void DeliverCard(CardView cardView)
    {
        UserDecksController.InsertIntoDeck(_deckModel.discardDeck, cardView);     
    }
}

public interface ICroupier
{
    void InsertIntoDeck(IDeck deck, CardView cardView);
    void DeliverCard(CardView cardView);
}

