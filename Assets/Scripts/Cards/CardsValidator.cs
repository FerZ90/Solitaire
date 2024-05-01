public static class CardsValidator
{
    public static bool CompatibleWith(CardInfo higherCard, CardInfo lowerCard)
    {
        bool checkSuits = CheckCompatibleSuit(higherCard, lowerCard);
        bool checkValues = (int)higherCard.value - 1 == (int)lowerCard.value;

        return checkSuits && checkValues;
    }   

    private static bool CheckCompatibleSuit(CardInfo first, CardInfo second)
    {
        var firstCondition = (first.suit == CardSuit.Diamonds || first.suit == CardSuit.Hearts) && (second.suit == CardSuit.Spades || second.suit == CardSuit.Clovers);

        var secondCondition = (first.suit == CardSuit.Clovers || first.suit == CardSuit.Spades) && (second.suit == CardSuit.Hearts || second.suit == CardSuit.Diamonds);

        return firstCondition || secondCondition;
    }
}
