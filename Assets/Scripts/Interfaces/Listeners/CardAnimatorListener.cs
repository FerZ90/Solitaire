public class CardAnimatorListener : Listener<ICardAnimatorListener>, ICardAnimatorListener
{
    public void OnAnimationStart(CardView card)
    {
        foreach (var listener in _listeners)
            listener?.OnAnimationStart(card);
    }

    public void OnAnimationEnd(CardView card)
    {
        foreach (var listener in _listeners)
            listener?.OnAnimationEnd(card);
    }
}



