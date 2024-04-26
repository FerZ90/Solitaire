public static class CardsValidator
{
    public static bool CompatibleWithPreviousCard(CardInfo previous, CardInfo current)
    {
        bool checkSuits = CheckCompatibleSuit(previous, current);
        bool checkValues = (int)previous.value + 1 == (int)current.value;

        return checkSuits && checkValues;
    }

    public static bool CompatibleWithNextCard(CardInfo current, CardInfo next)
    {
        bool checkSuits = CheckCompatibleSuit(current, next);
        bool checkValues = (int)current.value + 1 == (int)next.value;

        return checkSuits && checkValues;
    }

    private static bool CheckCompatibleSuit(CardInfo first,CardInfo second)
    {
        return (first.suit == CardSuit.Diamonds || first.suit == CardSuit.Hearts && second.suit == CardSuit.Spades || second.suit == CardSuit.Clovers) || (first.suit == CardSuit.Spades || first.suit == CardSuit.Clovers && second.suit == CardSuit.Diamonds || second.suit == CardSuit.Hearts);
    }
}
