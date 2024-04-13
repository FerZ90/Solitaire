using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Deck : IDeck
{
    private Transform _deckTransform;
    public List<CardView> DeckCards { get; set; }
    public Deck(Transform deckTransform)
    {     
        DeckCards = new List<CardView>();
        _deckTransform = deckTransform;
    }

    public Task AddCardToDeck(CardView card)
    {
        card.transform.SetParent(_deckTransform);

        if (DeckCards.Contains(card))
            Debug.LogError("Card already exists in Deck !!!");
        else
            DeckCards.Add(card);

        var position = GetNewCardPosition();

        return CardAnimator.AnimateCardToPosition(card, position);
    }

    public void RemoveCardFromDeck(CardView card)
    {
        if (!DeckCards.Contains(card))
            Debug.LogError("Card does not exist in Deck !!!");
        else
            DeckCards.Remove(card);
  
    }

    protected virtual Vector2 GetNewCardPosition()
    {
        return _deckTransform.position;
    }

}


