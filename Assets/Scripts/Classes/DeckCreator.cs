using System;
using System.Collections.Generic;
using System.Linq;


public static class DeckCreator
{   
    public static List<CardInfo> CreateDeck()
    {
        var cards = new List<CardInfo>();

        var cardsSuits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
        var cardsValues = (CardValue[])Enum.GetValues(typeof(CardValue));

        foreach (var cardSuit in cardsSuits)
        {
            foreach (var cardValue in cardsValues)
            {
                var card = new CardInfo
                {
                    value = cardValue,
                    suit = cardSuit,
                };

                cards.Add(card);
            }
        }

        Random random = new Random();
        cards = cards.OrderBy(x => random.Next()).ToList();

        return cards;
    }

}
