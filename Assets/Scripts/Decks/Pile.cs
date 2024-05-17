using System.Collections.Generic;
using UnityEngine;

public class Pile : MonoBehaviour, IPile
{
    protected IStack<CardView> _cards = new ListStack<CardView>();

    public bool Contains(CardView card)
    {
        return _cards.Elements.Contains(card);
    }

    public virtual Vector3 GetNewCardPosition(CardView card)
    {
        return transform.position;
    }

    public virtual void AddLast(CardView card)
    {
        _cards.AddLast(card);
    }

    public CardView GetLast()
    {
        return _cards.GetLast();
    }

    public virtual CardView RemoveLast()
    {
        return _cards.RemoveLast();
    }

    public List<CardView> GetNodeCards(CardView card)
    {
        return _cards.GetNodeItems(card);
    }


    public virtual bool TryInsertCard(CardView card)
    {
        return true;
    }

    public void PutCardviewOnDeck(CardView card)
    {
        int cardIndex = _cards.GetItemIndex(card);
        card.transform.SetParent(transform);
        card.transform.SetSiblingIndex(cardIndex);
    }
}



