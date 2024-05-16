using System;
using System.Collections.Generic;

[Serializable]
public class DeckModel
{
    public DeliveryDeck deliveryDeck;
    public Pile discardDeck;
    public List<InGameDeck> inGameDecks = new List<InGameDeck>();
    public List<FinishedDeck> finishedDecks = new List<FinishedDeck>();


    public void PrepareDecks(IDecksListener deckListener)
    {
        deliveryDeck.Setup(deckListener);

        foreach (var gameDeck in inGameDecks)
            gameDeck.Setup(deckListener);

        foreach (var finishedDeck in finishedDecks)
            finishedDeck.Setup(deckListener);
    }

}

