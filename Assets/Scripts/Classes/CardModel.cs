using UnityEngine;

public class CardModel
{
    public CardInfo cardSuitValue;
    public bool reverse;

    public CardModel(CardInfo cardData)
    {
        this.cardSuitValue = cardData;
    }

    public CardModel CopyCard()
    {
        return new CardModel(cardSuitValue)
        {               
            reverse = this.reverse        
        };
    }
}

