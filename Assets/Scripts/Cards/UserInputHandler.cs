using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserInputHandler : ICardInputHandlerListener
{
    private Transform parentAfterDrag;
    private IUserInputHandlerListener _listener;

    public UserInputHandler(IUserInputHandlerListener listener)
    {
        _listener = listener;
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
            _listener?.InsertIntoDeck(deck, card);
        else
            card.transform.SetParent(parentAfterDrag);

        parentAfterDrag = null;
        card.GetComponent<Image>().raycastTarget = true;
    }    
}

