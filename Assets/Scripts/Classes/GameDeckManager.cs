using System;
using System.Collections.Generic;
using System.Linq;


public class GameDeckManager
{
    public List<CardData> cards;
    public int score;
    public IDeck deliveryDeck;
    public IDeck discardDeck;
    public List<IDeck> inGameDecks;
    public List<IDeck> finishedDecks;

    public GameDeckManager()
    {  
        CreateDeck();
    }

    private void CreateDeck()
    {
        cards = new List<CardData>();

        var cardsSuits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
        var cardsValues = (CardValue[])Enum.GetValues(typeof(CardValue));

        foreach (var cardSuit in cardsSuits)
        {
            foreach (var cardValue in cardsValues)
            {
                var card = new CardData
                {
                    value = cardValue,
                    suit = cardSuit,
                };

                cards.Add(card);
            }
        }

        SuffleDeck();
    }

    private void SuffleDeck()
    {
        Random random = new Random();
        cards = cards.OrderBy(x => random.Next()).ToList();
    }
}
