using DG.Tweening;
using UnityEngine;

public class CardAnimator : ICardAnimator, IObservable<CardAnimatorObserverModel>
{
    public Observer<CardAnimatorObserverModel> Observer { get; set; } = new();

    public async void AnimateCardToPosition(CardView card, Vector3 to)
    {
        Observer.Notify(new CardAnimatorObserverModel(card, false));
        await card.GetComponent<RectTransform>().DOMove(to, 0.3f).AsyncWaitForCompletion();
        Observer.Notify(new CardAnimatorObserverModel(card, true));
    }

}
