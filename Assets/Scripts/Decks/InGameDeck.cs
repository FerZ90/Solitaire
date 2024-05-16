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
        //int cardIndex = _cards.GetItemIndex(card);
        //return new Vector3(transform.position.x, transform.position.y - (cardIndex * 40), transform.position.z);

        return new Vector3(transform.position.x, transform.position.y - (_cards.Elements.Count * 40), transform.position.z);
    }

}



