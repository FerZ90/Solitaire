
using UnityEngine.EventSystems;

public interface ICardInputHandlerListener
{
    void OnBeginDragCard(PointerEventData eventData, CardView card);
    void OnDragCard(PointerEventData eventData, CardView card);
    void OnEndDragCard(PointerEventData eventData, CardView card);
}
