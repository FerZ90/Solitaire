
public class CardModel
{
    public CardInfo cardSuitValue;
    public IDeck deck;

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

}

