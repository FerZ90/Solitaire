using System;
using System.Collections.Generic;

[Serializable]
public class DeckModel
{
    public DeliveryPile deliveryDeck;
    public Pile discardDeck;
    public List<InGameDeck> inGameDecks = new List<InGameDeck>();
    public List<FinishedDeck> finishedDecks = new List<FinishedDeck>();

    public void PrepareDecks(IDeliveryPileListener pileClickListener, IDropPileListener dropPileListener, InGameDeckListener inGameDeckListener)
    {
        deliveryDeck.Setup(pileClickListener);

        foreach (var gameDeck in inGameDecks)
        {
            gameDeck.Setup(dropPileListener);
            gameDeck.Setup(inGameDeckListener);
        }

        foreach (var finishedDeck in finishedDecks)
            finishedDeck.Setup(dropPileListener);
    }

}

