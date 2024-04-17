using UnityEngine;

public class InGameDeck : Deck
{
    protected override Vector2 GetNewCardPosition()
    {
        return new Vector3(transform.position.x, transform.position.y - (_deckCards.Count * 30), transform.position.z);
    }

    public override void RemoveCardFromDeck(CardView card)
    {
        if (card == null)
            return;

        base.RemoveCardFromDeck(card);

        Debug.Log("RemoveCardFromDeck_00");

        var lastCard = GetLastCard(false);
        if (lastCard != null)
        {   
            lastCard.SetReverse(false);
        }
  
    }
}
