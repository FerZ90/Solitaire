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
            return CardsValidator.CompatibleWithPreviousCard(card.CardModel.cardSuitValue, lastCard.CardModel.cardSuitValue);
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

    public void OnDrop(PointerEventData eventData)
    {
        _listener?.OnDropCardInDeck(this, eventData);
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


