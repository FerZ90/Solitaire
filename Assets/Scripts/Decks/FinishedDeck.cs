
using UnityEngine.EventSystems;

public class FinishedDeck : Pile, IDropablePile
{
    private IDropableListener _listener;
    public void Setup(IDropableListener listener)
    {
        _listener = listener;
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

}
