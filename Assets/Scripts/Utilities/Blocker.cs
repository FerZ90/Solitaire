using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Blocker : MonoBehaviour, IObserver<CardAnimatorObserverModel>
{
    private Image blockerImage;

    private void Awake()
    {
        blockerImage = GetComponent<Image>();
        blockerImage.enabled = false;
    }

    public void Setup(IObservable<CardAnimatorObserverModel> observable)
    {
        observable.Observer.Subscribe(this);
    }

    public void UpdateEvent(CardAnimatorObserverModel parameter)
    {
        blockerImage.enabled = !parameter.animationFinish;
    }
}



