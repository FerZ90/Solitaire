using DG.Tweening;
using UnityEngine;

public class CardAnimator : ICardTranslatorListener
{
    private ICardAnimatorListener _listener;

    public CardAnimator(ICardAnimatorListener listener)
    {
        _listener = listener;
    }

    public async void AnimateCardToPosition(CardView card, Vector3 to)
    {
        _listener.OnAnimationStart(card);
        await card.GetComponent<RectTransform>().DOMove(to, 0.3f).AsyncWaitForCompletion();
        _listener.OnAnimationEnd(card);
    }

}

public interface ICardAnimatorListener
{
    void OnAnimationStart(CardView card);
    void OnAnimationEnd(CardView card);
}
