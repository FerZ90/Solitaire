using UnityEngine;

public class CardModel
{    
    public CardInfo cardSuitValue;
    public IPile deck;
    public Sprite cardImg;
    public Sprite backgroundImg;

    public CardModel(CardInfo cardData)
    {
        this.cardSuitValue = cardData;     
    }

    public CardModel(CardInfo cardData, Sprite cardImg, Sprite backgroundImg)
    {
        this.cardSuitValue = cardData;
        this.cardImg = cardImg;
        this.backgroundImg = backgroundImg;
    }

    public CardModel CopyCard()
    {
        return new CardModel(cardSuitValue)
        {

        };
    }      

    public void LogCard()
    {
        Debug.Log($"<color=cyan>Card Value: {cardSuitValue.value} || Card Suit: {cardSuitValue.suit}</color>");
    }

}

