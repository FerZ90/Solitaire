using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardView> DeckCards { get; set; }

    //private CardAnimator _cardAnimator;

    public void Initialize(/*CardAnimator cardAnimator*/)
    {
        DeckCards = new List<CardView>();
        //_cardAnimator = cardAnimator;
    }

    public virtual Task AddCardToDeck(CardView card)
    {
        card.transform.SetParent(transform);

        if (DeckCards.Contains(card))
            Debug.LogError("Card already exists in Deck !!!");
        else
            DeckCards.Add(card);

        var position = GetNewCardPosition();

        return CardAnimator.AnimateCardToPosition(card, position);
    }

    public virtual void RemoveCardFromDeck(CardView card)
    {
        if (!DeckCards.Contains(card))
            Debug.LogError("Card does not exist in Deck !!!");
        else
            DeckCards.Remove(card);
  
    }

    protected virtual Vector2 GetNewCardPosition()
    {
        return transform.position;
    }
}
