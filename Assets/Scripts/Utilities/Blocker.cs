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

    public void Setup(ISubjectType<PileObserverModel> deckModel)
    {
        blockerImage.enabled = false;
        deckModel.Observer.Subscribe(this);     
    }

    public void UpdateEvent(PileObserverModel observer)
    {
        if (observer != null && observer is PileObserverModel)
            blockerImage.enabled = !observer.finishAnimation;
    }

}
