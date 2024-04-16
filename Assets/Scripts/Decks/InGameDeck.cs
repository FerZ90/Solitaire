using UnityEngine;

public class InGameDeck : Deck
{
    protected override Vector2 GetNewCardPosition()
    {
        return new Vector3(transform.position.x, transform.position.y - (_deckCards.Count * 30), transform.position.z);
    }
}
