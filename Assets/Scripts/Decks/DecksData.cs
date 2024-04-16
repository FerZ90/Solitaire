using System;
using System.Collections.Generic;

[Serializable]
public class DecksData
{
    public Deck deliveryDeck;
    public Deck discardDeck;
    public List<InGameDeck> inGameDecks = new List<InGameDeck>();
    public List<FinishedDeck> finishedDecks = new List<FinishedDeck>();
}

