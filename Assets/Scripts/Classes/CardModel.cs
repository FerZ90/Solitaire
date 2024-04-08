
public class CardModel
{
    public CardSuit suit;
    public CardValue value;

    public CardModel CopyCard()
    {
        return new CardModel
        {
            suit = this.suit,
            value = this.value
        };
    }
}
