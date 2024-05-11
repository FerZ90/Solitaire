using System;
using System.Collections.Generic;
using System.Linq;


public class DeckCreator : ICardsCreatorData
{   
    public List<CardInfo> CreateDeck()
    {
        var gameCards = new List<CardInfo>();

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

                gameCards.Add(card);
            }
        }

        Random random = new Random();
        gameCards = gameCards.OrderBy(x => random.Next()).ToList();

        return gameCards;
    }

}

public interface ICardsCreatorData
{
    public List<CardInfo> CreateDeck();

}

