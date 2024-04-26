using UnityEngine;

public class InGameDeck : MonoBehaviour
{   

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


