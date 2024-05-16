using DG.Tweening;
using UnityEngine;

public class CardAnimator : ICardAnimator
{
    private ICardAnimatorListener _listener;
    public CardAnimator(ICardAnimatorListener listener)
    {
        _listener = listener;
    }

    public async void AnimateCardToPosition(CardView card, Vector3 to)
    {
        _listener?.StartAnimation();
        await card.GetComponent<RectTransform>().DOMove(to, 0.3f).AsyncWaitForCompletion();
        _listener?.FinishAnimation();
    }

}
