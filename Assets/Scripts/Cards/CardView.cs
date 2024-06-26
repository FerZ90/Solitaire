using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private CardModel _cardModel;
    private bool _reverse = true;
    private Image _image;
    public CardModel CardModel => _cardModel;
    public bool Reverse => _reverse;

    private ICardViewListener _listener;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Setup(ICardViewListener listener)
    {
        _listener = listener;
    }

    public void SetupModel(CardModel cardModel)
    {
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
        _listener.OnBeginDrag(this, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _listener.OnDrag(this, eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _listener.OnEndDrag(this, eventData);
    }

    public void SetReverse(bool reverse)
    {
        _reverse = reverse;
        UpdateCardInfo();
    }
}

public interface ICardViewListener
{
    void OnBeginDrag(CardView card, PointerEventData eventData);
    void OnDrag(CardView card, PointerEventData eventData);
    void OnEndDrag(CardView card, PointerEventData eventData);
}



