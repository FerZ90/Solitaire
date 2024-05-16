using UnityEngine;

public interface ICardAnimator : IObservable<CardAnimatorObserverModel>
{
    void AnimateCardToPosition(CardView card, Vector3 to);
}
