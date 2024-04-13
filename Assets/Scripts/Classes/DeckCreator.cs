using System;
using System.Collections.Generic;
using System.Linq;


public class DeckCreator: IDeckCreator
{
    private List<CardInfo> _gameCards;

    public List<CardInfo> GameCards => _gameCards;

    public DeckCreator()
    {
        CreateDeck();
    }

    public List<CardInfo> CreateDeck()
    {
        _gameCards = new List<CardInfo>();

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

                _gameCards.Add(card);
            }
        }

        Random random = new Random();
        _gameCards = _gameCards.OrderBy(x => random.Next()).ToList();

        return _gameCards;
    }

}

public interface IDeckCreator
{
    public List<CardInfo> GameCards { get; }
    public List<CardInfo> CreateDeck();
}
