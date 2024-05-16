using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private CardModel _cardModel;
    private bool _reverse = true;
    private Image _image;
    private ICardviewListener _listener;
    public CardModel CardModel => _cardModel;
    public bool Reverse => _reverse;


    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Setup(ICardviewListener listener, CardModel cardModel)
    {
        _listener = listener;
        _cardModel = cardModel;
        _image.sprite = _cardModel.backgroundImg;
        UpdateCardInfo();
    }

    public void UpdateCard()
    {
        UpdateCardInfo();
    }

    private void UpdateCardInfo()
    {
        if (_reverse)
            _image.overrideSprite = null;
        else
            _image.overrideSprite = CardModel.cardImg;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _listener?.OnBeginDragCard(eventData, this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _listener?.OnDragCard(eventData, this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _listener?.OnEndDragCard(eventData, this);
    }

    public void SetReverse(bool reverse)
    {
        _reverse = reverse;
        UpdateCardInfo();
    }
}



