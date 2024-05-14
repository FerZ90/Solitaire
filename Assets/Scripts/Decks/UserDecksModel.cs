using System;
using System.Collections.Generic;

[Serializable]
public class DeckModel : ISubjectType<PileObserverModel>, IObserver<PileObserverModel>
{
    public DeliveryDeck deliveryDeck;
    public Pile discardDeck;
    public List<InGameDeck> inGameDecks = new List<InGameDeck>();
    public List<FinishedDeck> finishedDecks = new List<FinishedDeck>();

    public Observer<PileObserverModel> Observer { get; set; } = new Observer<PileObserverModel>();

    public void PrepareDecks(IDecksListener decksListener)
    {
        deliveryDeck.Setup(decksListener);

        foreach (var gameDeck in inGameDecks)
            gameDeck.Setup(decksListener);

        foreach (var finishedDeck in finishedDecks)
            finishedDeck.Setup(decksListener);

        SuscribeEvents();
    }

    private void SuscribeEvents()
    {
        deliveryDeck.Observer.Subscribe(this);
        discardDeck.Observer.Subscribe(this);

        foreach (var gameDeck in inGameDecks)
            gameDeck.Observer.Subscribe(this);

        foreach (var finishedDeck in finishedDecks)
            finishedDeck.Observer.Subscribe(this);
    }

    public void UpdateEvent(PileObserverModel parameter)
    {
        Observer.Notify(parameter);
    }
}

