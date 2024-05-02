using System;
using System.Collections.Generic;

[Serializable]
public class DeckModel
{
    public DeliveryDeck deliveryDeck;
    public Pile discardDeck;
    public List<InGameDeck> inGameDecks = new List<InGameDeck>();
    public List<FinishedDeck> finishedDecks = new List<FinishedDeck>();

    public void PrepareDecks(IDecksListener decksListener)
    {
        deliveryDeck.Setup(decksListener);

        foreach (var gameDeck in inGameDecks)
            gameDeck.Setup(decksListener);


    }
}

