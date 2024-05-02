
public class FinishedDeck : Pile
{
    public override bool TryInsertCard(CardView card)
    {
        var lastCard = base.GetLast();

        if (lastCard == null)
        {
            return card.CardModel.cardSuitValue.value == CardValue.Ace;
        }
        else
        {
            return CardsValidator.CompatibleWithSameSuit(card.CardModel.cardSuitValue, lastCard.CardModel.cardSuitValue);
        }
    }

}
