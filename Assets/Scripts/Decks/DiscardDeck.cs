using UnityEngine;

public class DiscardDeck : Deck
{
    protected override Vector3 GetCardPosition(CardView card)
    {
        return transform.position;
    }

    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        card.SetReverse(false);
    }
}

