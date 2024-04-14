using System;
using System.Collections.Generic;

[Serializable]
public class DeckInspectorData
{
    public Deck deliveryDeck;
    public Deck discardDeck;
    public List<Deck> inGameDecks = new List<Deck>();
    public List<Deck> finishedDecks = new List<Deck>();
}

