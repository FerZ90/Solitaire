using System;
using System.Collections.Generic;

[Serializable]
public class DeckModel
{
    public DeliveryPile deliveryDeck;
    public Pile discardDeck;
    public List<InGameDeck> inGameDecks = new List<InGameDeck>();
    public List<FinishedDeck> finishedDecks = new List<FinishedDeck>();

    public void PrepareDecks()
    {
        //deliveryDeck.Observer.Subscribe(cardMovementObserver);

        //foreach (var gameDeck in inGameDecks)
        //    gameDeck.Observer.Subscribe(cardMovementObserver);

        //foreach (var finishedDeck in finishedDecks)
        //    finishedDeck.Observer.Subscribe(cardMovementObserver);
    }

}

