using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInputHandler : ICardInputHandlerListener
{
    private Transform parentAfterDrag;
    private IDecksController _decksController;

    public CardInputHandler(IDecksController decksController)
    {
        _decksController = decksController;
    }

    public void OnBeginDragCard(PointerEventData eventData, CardView card)
    {
        parentAfterDrag = card.transform.parent;
        card.transform.SetParent(card.transform.root);
        card.transform.SetAsLastSibling();
        card.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDragCard(PointerEventData eventData, CardView card)
    {
        card.transform.position = eventData.position;
    }

    public void OnEndDragCard(PointerEventData eventData, CardView card)
    {
        if (!eventData.pointerDrag.TryGetComponent<Deck>(out var deck))
            _decksController.InsertIntoDeck(deck, card);
        else
            card.transform.SetParent(parentAfterDrag);

        parentAfterDrag = null;
        card.GetComponent<Image>().raycastTarget = true;
    }    
}
