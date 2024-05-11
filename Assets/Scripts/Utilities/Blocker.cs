using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Blocker : MonoBehaviour, IObserver<PileObserverModel>
{
    private Image blockerImage;

    private void Awake()
    {
        blockerImage = GetComponent<Image>();
    }

    public void Setup(DeckModel deckModel)
    {
        blockerImage.enabled = false;

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

    public void UpdateEvent(PileObserverModel observer)
    {
        if (observer != null && observer is PileObserverModel)
            blockerImage.enabled = !observer.finishAnimation;
    }

}
