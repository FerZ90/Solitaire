
using UnityEngine.EventSystems;

public class FinishedDeck : Pile, IDropablePile
{
    private IDropableListener _listener;
    public bool IsComplete { get; private set; }

    public void Setup(IDropableListener listener)
    {
        _listener = listener;
    }

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

    public void OnDrop(PointerEventData eventData)
    {
        _listener?.OnDropCardInDeck(this, eventData);
    }
 
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

    private void CheckIfComplete()
    {
        IsComplete = _cards.Elements.Count >= 13;
    }

}
