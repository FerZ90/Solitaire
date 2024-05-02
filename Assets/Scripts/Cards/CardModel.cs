
public class CardModel
{    
    public CardInfo cardSuitValue;
    public IPile deck;

    public CardModel(CardInfo cardData)
    {
        this.cardSuitValue = cardData;     
    }

    public CardModel CopyCard()
    {
        return new CardModel(cardSuitValue)
        {

        };
    }      

    public void LogCard()
    {
        UnityEngine.Debug.Log($"<color=cyan>Card Value: {cardSuitValue.value} || Card Suit: {cardSuitValue.suit}</color>");
    }

}

