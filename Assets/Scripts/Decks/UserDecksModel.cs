using System;
using System.Collections.Generic;

[Serializable]
public class DeckModel
{
    public Deck deliveryDeck;
    public Deck discardDeck;
    public List<Deck> inGameDecks = new List<Deck>();
    public List<Deck> finishedDecks = new List<Deck>();

    public void PrepareDecks(IDeckInputHandlerListener listener)
    {
        deliveryDeck.Setup(listener);
        discardDeck.Setup(listener);

        foreach (var gameDeck in inGameDecks)
            gameDeck.Setup(listener);

        foreach (var finishedDeck in finishedDecks)
            finishedDeck.Setup(listener);
    }
}

