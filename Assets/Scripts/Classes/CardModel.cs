using UnityEngine;

public class CardModel
{
    public CardData cardData;
    public bool reverse;
    public Sprite texture;

    public CardModel(CardData cardData)
    {
        this.cardData = cardData;
    }

    public CardModel CopyCard()
    {
        return new CardModel(cardData)
        {               
            reverse = this.reverse,
            texture = this.texture
        };
    }
}
