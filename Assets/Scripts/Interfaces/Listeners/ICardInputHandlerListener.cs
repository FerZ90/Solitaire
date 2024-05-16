using UnityEngine.EventSystems;

public interface ICardInputHandlerListener
{
    void OnBeginDragCard(PointerEventData eventData, CardView cards);
    void OnDragCard(PointerEventData eventData, CardView card);
    void OnEndDragCard(PointerEventData eventData, CardView card);
}
