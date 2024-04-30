using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, IDeck
{
    private IStack<CardView> _cards;

    public List<CardView> Cards;  //Test propose

    private void Awake()
    {  
        _cards = new ListStack<CardView>();
        Cards = new List<CardView>();  //Test propose
    }  

    protected virtual Vector3 GetCardPosition(CardView card)
    {
        int cardIndex = _cards.GetItemIndex(card);

        return new Vector3(transform.position.x, transform.position.y - (cardIndex * 30), transform.position.z);      
    }

    public virtual void AddLast(CardView card)
    {
        bool success = _cards.AddLast(card);

        if (!success)
            return;

        PutCardviewOnDeck(card);

        Cards.Add(card); //Test propose
    }

    public CardView GetLast()
    {
        return _cards.GetLast();
    }

    public virtual CardView RemoveLast()
    {
        Cards.Remove(Cards[Cards.Count - 1]); //Test propose    
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

    public virtual bool IsValidDragging(CardView card)
    {
        return !card.Reverse;
    }

    private async void PutCardviewOnDeck(CardView card)
    {
        await CardAnimator.AnimateCardToPosition(card, GetCardPosition(card));

        int cardIndex = _cards.GetItemIndex(card);
        card.transform.SetParent(transform);
        card.transform.SetSiblingIndex(cardIndex);
    }
  

    #region OLD
    //protected LinkedList<CardView> _deckCards;
    //protected IDeckInputHandlerListener _listener;

    //public void Awake()
    //{     
    //    _deckCards = new LinkedList<CardView>();  
    //}

    //public void Initialize(IDeckInputHandlerListener listener)
    //{
    //    _listener = listener;
    //}

    //public virtual Task AddCardToDeck(CardView card)
    //{
    //    Debug.Log("<color=green> << AddCardToDeck >> </color>");

    //    if (_deckCards.Contains(card))
    //        return Task.Run(() => { });

    //    card.transform.SetParent(transform);
    //    card.transform.SetAsLastSibling();
    //    var position = GetNewCardPosition();

    //    if (!_deckCards.Contains(card))
    //        _deckCards.AddLast(card);

    //    card.CardModel.deck = this;

    //    return CardAnimator.AnimateCardToPosition(card, position);
    //}

    //public virtual void RemoveCardFromDeck(CardView card)
    //{
    //    Debug.Log("<color=red> << RemoveCardFromDeck >> </color>");

    //    var lastCard = GetLastCard(false);

    //    if (lastCard != null && lastCard == card)
    //    {
    //        _deckCards.Remove(card);
    //        card.CardModel.deck = null;
    //    }      
    //}

    //public void ReturnCardToDeck(CardView card)
    //{
    //    Debug.Log("<color=white> << ReturnCardToDeck >> </color>");

    //    if (_deckCards.Contains(card))
    //    {
    //        card.transform.SetParent(transform);
    //        card.transform.SetAsLastSibling();
    //        var position = GetNewCardPosition();
    //        CardAnimator.AnimateCardToPosition(card, position);
    //    }     
    //}


    //public virtual CardView GetLastCard(bool removeCard)
    //{
    //    CardView card = null;

    //    if (_deckCards != null && _deckCards.Count > 0)
    //    {
    //        card = _deckCards.Last.Value;
    //        if (removeCard)
    //            RemoveCardFromDeck(card);
    //    }

    //    return card;
    //}

    //protected virtual Vector2 GetNewCardPosition()
    //{
    //    return transform.position;
    //}

    //public virtual bool TryInsertCard(CardView card)
    //{
    //    return true;
    //}

    //public virtual bool IsValidDragging(CardView card)
    //{
    //    return !card.Reverse;
    //}

    //public void OnDrop(PointerEventData eventData)
    //{
    //    _listener?.OnDropCardInDeck(this, eventData);      
    //}
    #endregion OLD

}


