using System.Collections.Generic;
using UnityEngine;

public class Pile : MonoBehaviour, IPile
{
    protected IStack<CardView> _cards = new ListStack<CardView>();

    public virtual Vector3 GetCardPosition(CardView card)
    {
        return transform.position;
    }

    public virtual void AddLast(CardView card)
    {
        bool success = _cards.AddLast(card);

        if (!success)
            return;

        PutCardviewOnDeck(card);
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

    public void ReturnCardToDeck(CardView card)
    {
        PutCardviewOnDeck(card);
    }

    public virtual bool TryInsertCard(CardView card)
    {
        return true;
    }

    private void PutCardviewOnDeck(CardView card)
    {
        //card.transform.SetParent(transform.root);
        //card.transform.SetAsLastSibling();

        //_listener?.StartInsertCard();

        //await CardAnimator.AnimateCardToPosition(card, GetCardPosition(card));

        int cardIndex = _cards.GetItemIndex(card);
        card.transform.SetParent(transform);
        card.transform.SetSiblingIndex(cardIndex);

        //_listener?.FinishInsertCard();
    }

}



