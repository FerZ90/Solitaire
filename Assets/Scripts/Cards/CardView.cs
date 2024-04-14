using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private TextMeshProUGUI cardValueTxt;
    [SerializeField] private TextMeshProUGUI cardSuitTxt;

    private CardModel _cardModel;
    private Sprite _cardSprite;
    private Image _image;
    private ICardListener _cardListener;

    public CardModel CardModel => _cardModel;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Setup(CardModel cardModel, Sprite cardSprite, Sprite reverseSprite)
    {
        _cardModel = cardModel;
        _cardSprite = cardSprite;  

        if (reverseSprite != null)
        {
            _image.sprite = reverseSprite;

            if (!_cardModel.reverse)
                _image.overrideSprite = cardSprite;
        }

        UpdateCardInfo();
    }

    public void SetListener(ICardListener cardListener)
    {
        _cardListener = cardListener;
    }

    public void UpdateCard()
    {
        if (!_cardModel.reverse)
            _image.overrideSprite = _cardSprite;
        else
            _image.overrideSprite = null;

        UpdateCardInfo();
    }

    private void UpdateCardInfo()
    {
        if (_cardModel.reverse)
        {
            _image.color = Color.black;
            cardValueTxt.text = null;
            cardSuitTxt.text = null;
        }
        else
        {
            _image.color = Color.white;
            cardValueTxt.text = _cardModel.cardSuitValue.value.ToString();
            cardSuitTxt.text = _cardModel.cardSuitValue.suit.ToString();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            var selectedGO = EventSystem.current.currentSelectedGameObject;
            if (selectedGO != null && selectedGO.TryGetComponent<Deck>(out var newDeck))
            {
                _cardListener?.OnFinishDrag(newDeck, this);
                return;
            }          
        }

        _cardListener?.OnFinishDrag(null, this);

    }
}
