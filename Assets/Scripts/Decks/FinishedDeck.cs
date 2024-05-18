public class FinishedDeck : DropPile
{
    public bool IsComplete { get; private set; }

    public override void AddLast(CardView card)
    {
        if (IsComplete)
            return;

        base.AddLast(card);
        CheckIfComplete();
    }

    public override CardView RemoveLast()
    {
        var card = base.RemoveLast();
        CheckIfComplete();
        return card;
    }

    public override bool TryInsertCard(CardView card)
    {
        var lastCard = GetLast();

        if (lastCard == null)
        {
            return card.CardModel.cardSuitValue.value == CardValue.Ace;
        }
        else
        {
            return CardsValidator.CompatibleWithSameSuit(card.CardModel.cardSuitValue, lastCard.CardModel.cardSuitValue);
        }
    }

    private void CheckIfComplete()
    {
        IsComplete = _cards.Elements.Count >= 13;
    }

}
