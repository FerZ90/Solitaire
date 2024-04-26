using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, IDeck
{
    private NodeStack<CardView> _cards;
    private ICardValidator _cardValidator;

    private void Awake()
    {  
        _cards = new NodeStack<CardView>();
    }

    public void Setup(ICardValidator cardValidator)
    {
        
    }

    protected virtual Vector3 GetCardPosition(CardView card)
    {
        int cardIndex = _cards.GetItemIndex(card);

        return new Vector3(transform.position.x, transform.position.y - (cardIndex * 30), transform.position.z);      
    }

    public void AddLast(CardView card)
    {
        card.transform.SetParent(transform);
        card.transform.SetAsLastSibling();
        _cards.AddLast(card);

        card.transform.position = GetCardPosition(card);
    }

    public CardView RemoveLast()
    {
        return _cards.RemoveLast();
    }

    public List<CardView> GetNodeCards(CardView card)
    {
        return _cards.GetNodeItems(card);
    }

    public bool TryInsertCard(CardView card)
    {
        return true;
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


