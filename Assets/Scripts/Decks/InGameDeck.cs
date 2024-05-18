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

    public override Vector3 GetNewCardPosition(CardView card)
    {
        int positionsIndex = _cards.GetItemIndex(card);
        return new Vector3(transform.position.x, transform.position.y - (positionsIndex * 40), transform.position.z);
    }

}



