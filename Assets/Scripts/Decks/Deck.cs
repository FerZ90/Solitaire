using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour, IDeck, IDropHandler
{
    private List<CardView> _deckCards;
    private IDecksController _decksController;

    public void Awake()
    {     
        _deckCards = new List<CardView>();  
    }

    public void Initialize(IDecksController decksController)
    {
        _decksController = decksController;
    }

    public Task AddCardToDeck(CardView card)
    {
        card.transform.SetParent(transform);

        if (!_deckCards.Contains(card))
            _deckCards.Add(card);  

        var position = GetNewCardPosition();

        return CardAnimator.AnimateCardToPosition(card, position);
    }

    public void RemoveCardFromDeck(CardView card)
    {
        if (_deckCards.Contains(card)) 
            _deckCards.Remove(card);  
    }

    protected virtual Vector2 GetNewCardPosition()
    {
        return transform.position;
    }

    public bool TryInsertCard(CardView card)
    {
        return true;       
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<CardView>(out var cardView))
        {
            if (TryInsertCard(cardView))
                _decksController.InsertIntoDeck(this, cardView);
        }
    }
}


