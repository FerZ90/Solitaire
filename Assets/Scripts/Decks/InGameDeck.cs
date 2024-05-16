using UnityEngine;

public class InGameDeck : DropPile
{
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

    public override Vector3 GetCardPosition(CardView card)
    {
        int cardIndex = _cards.GetItemIndex(card);
        return new Vector3(transform.position.x, transform.position.y - (cardIndex * 40), transform.position.z);
    }


    #region OLD
    //private void CheckIfDeckIsComplete()
    //{
    //    if (_cards.Elements.Count < 13 || _cards.Elements.Count <= 0)
    //        return;

    //    var completeDeck = new List<CardView>();  

    //    for (int i = _cards.Elements.Count - 1; i >= 0; i--)
    //    {
    //        if (_cards.Elements[i].Reverse)
    //            break;

    //        completeDeck.Add(_cards.Elements[i]);

    //        if (completeDeck.Count >= 13)
    //            break;       
    //    }

    //    Debug.Log($"CheckIfDeckIsComplete_01 | completeDeck Count: {completeDeck.Count}");

    //    if (completeDeck.Count == 13 && _cards.Elements.All(c => !c.Reverse))
    //        _listener?.OnDeckComplete(completeDeck);
    //}


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


