using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public class InGameDeck : Deck, IDropHandler
{
    private IGameDeckListener _listener;

    public void Setup(IGameDeckListener listener)
    {
        _listener = listener;
    }

    public override bool TryInsertCard(CardView card)
    {
        var lastCard = base.GetLast();

        if (lastCard == null)
        {
            return card.CardModel.cardSuitValue.value == CardValue.King;
        }
        else
        {
            return CardsValidator.CompatibleWith(lastCard.CardModel.cardSuitValue, card.CardModel.cardSuitValue);
        }     
    }

    public override CardView RemoveLast()
    {
        var removeCard = base.RemoveLast();
        var lastCard = base.GetLast();

        if (lastCard != null)
            lastCard.SetReverse(false);

        return removeCard;
    }

    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        CheckIfDeckIsComplete();
    }

    public void OnDrop(PointerEventData eventData)
    {
        _listener?.OnDropCardInDeck(this, eventData);
    }

    private void CheckIfDeckIsComplete()
    {
        if (_cards.Elements.Count < 13 || _cards.Elements.Count <= 0)
            return;

        var completeDeck = new List<CardView>();
        completeDeck.Add(_cards.Elements[_cards.Elements.Count - 1]);

        for (int i = _cards.Elements.Count - 1; i >= 0; i--)
        {
            var card = _cards.Elements[i];

            if (card.Reverse)
                break;

            UnityEngine.Debug.Log($"Compare Cards | 1st: '{_cards.Elements[i - 1].CardModel.cardSuitValue.value},{_cards.Elements[i - 1].CardModel.cardSuitValue.suit}' | 2nd: '{card.CardModel.cardSuitValue.value},{card.CardModel.cardSuitValue.suit}'");

            if (i - 1 >= 0 && CardsValidator.CompatibleWith(_cards.Elements[i - 1].CardModel.cardSuitValue, card.CardModel.cardSuitValue) && !_cards.Elements[i - 1].Reverse)
                completeDeck.Add(card);
            else
                break;
        }

        UnityEngine.Debug.Log($"CheckIfDeckIsComplete_01 | completeDeck Count: {completeDeck.Count}");

        if (completeDeck.Count == 13 && _cards.Elements.All(c => !c.Reverse))
            _listener?.OnDeckComplete(null);
    }

    #region OLD
    //protected override Vector2 GetNewCardPosition()
    //{
    //    return new Vector3(transform.position.x, transform.position.y - (_deckCards.Count * 30), transform.position.z);
    //}

    //public override Task AddCardToDeck(CardView card)
    //{
    //    var lastCard = GetLastCard(false);
    //    var task = base.AddCardToDeck(card);

    //    if (card != null && lastCard != null)
    //        card.transform.SetParent(lastCard.transform);
    //    return task;
    //}

    //private async void CheckIfDeckIsComplete()
    //{
    //    if (_deckCards.Count == 13 && _deckCards.All(c => !c.Reverse))
    //    {
    //        while (_deckCards.Count > 0)
    //        {
    //            var lastCard = GetLastCard(true);
    //            await Task.Delay(100);
    //        }

    //        return;
    //    }
    //}

    //public override void RemoveCardFromDeck(CardView card)
    //{
    //    if (card == null)
    //        return;

    //    base.RemoveCardFromDeck(card);
    //    CheckIfReverseLastCard(card);
    //}

    //private void CheckIfReverseLastCard(CardView card)
    //{
    //    var lastCard = GetLastCard(false);

    //    if (lastCard != null && lastCard != card)
    //    {
    //        card.CardModel.LogCard();
    //        lastCard.SetReverse(false);
    //    }
    //}

    //public override bool IsValidDragging(CardView card)
    //{
    //    return true;
    //    return base.IsValidDragging(card);
    //}
    #endregion
}


