using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Deck : MonoBehaviour, IDeck
{   
    private List<CardView> DeckCards { get; set; }

    public void Awake()
    {     
        DeckCards = new List<CardView>();  
    }

    public Task AddCardToDeck(CardView card)
    {
        card.transform.SetParent(transform);

        if (!DeckCards.Contains(card))
            DeckCards.Add(card);  

        var position = GetNewCardPosition();

        return CardAnimator.AnimateCardToPosition(card, position);
    }

    public void RemoveCardFromDeck(CardView card)
    {
        if (DeckCards.Contains(card)) 
            DeckCards.Remove(card);  
    }

    protected virtual Vector2 GetNewCardPosition()
    {
        return transform.position;
    }

    public bool TryInsertCard(CardView card)
    {
        return true;
        //throw new System.NotImplementedException();
    }
}


