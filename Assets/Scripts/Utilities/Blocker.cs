using UnityEngine.UI;

public class Blocker : IObserver<CardViewObserverModel>
{
    private Image _blocker;

    public Blocker(Image uiBlocker, DeckModel deckModel)
    {
        _blocker = uiBlocker;
        uiBlocker.enabled = false;

        deckModel.deliveryDeck.PileObserver.Subscribe(this);
        deckModel.discardDeck.PileObserver.Subscribe(this);

        foreach (var finishedDeck in deckModel.finishedDecks)
        {
            finishedDeck.PileObserver.Subscribe(this);
        }

        foreach (var ingameDeck in deckModel.inGameDecks)
        {
            ingameDeck.PileObserver.Subscribe(this);
        }
    }

    public void UpdateEvent(CardViewObserverModel observer)
    {
        if (observer != null && observer is CardViewObserverModel)
            _blocker.enabled = !observer.finishAnimation;
    }

}
