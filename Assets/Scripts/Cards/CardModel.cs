
public class CardModel
{
    public CardInfo cardSuitValue;
    public bool reverse = false;
    public IDeck deck;

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

