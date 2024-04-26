using UnityEngine;

public class DeliveryDeck : Deck
{
    protected override Vector3 GetCardPosition(CardView card)
    {
        return transform.position;
    }

}
