using UnityEngine;
using UnityEngine.EventSystems;

public class DeliveryDeck : Deck, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var lastCard = RemoveLast();

        if (lastCard != null) 
            _listener?.OnCroupierClick(eventData, lastCard);
    }

    protected override Vector3 GetCardPosition(CardView card)
    {
        return transform.position;
    }

}
