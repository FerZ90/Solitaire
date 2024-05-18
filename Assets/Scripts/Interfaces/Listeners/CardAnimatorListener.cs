using System.Collections.Generic;

public class CardAnimatorListener : ICardAnimatorListener
{
    private List<ICardAnimatorListener> _listeners;

    public CardAnimatorListener()
    {
        _listeners = new List<ICardAnimatorListener>();
    }

    public void AddListener(ICardAnimatorListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(ICardAnimatorListener listener)
    {
        _listeners.Remove(listener);
    }

    public void OnAnimationStart(CardView card)
    {
        foreach (var listener in _listeners)
            listener?.OnAnimationStart(card);
    }

    public void OnAnimationEnd(CardView card)
    {
        UnityEngine.Debug.Log($"CardAnimatorListener OnAnimationEnd _listeners Count: {_listeners.Count}");

        foreach (var listener in _listeners)
            listener?.OnAnimationEnd(card);
    }
}



