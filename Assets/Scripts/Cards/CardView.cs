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
    private bool _reverse = true;
    private Image _image;
    private ICardInputHandlerListener _cardListener;

    public CardModel CardModel => _cardModel;
    public bool Reverse => _reverse;


    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Setup(CardModel cardModel, ICardInputHandlerListener cardListener)
    {
        _cardModel = cardModel;
        _cardListener = cardListener;

        UpdateCardInfo();
    }

    public void UpdateCard()
    {    
        UpdateCardInfo();      
    }

    private void UpdateCardInfo()
    {
        if (_reverse)
        {
            _image.color = Color.green;
            cardValueTxt.text = null;
            cardSuitTxt.text = null;
        }
        else
        {
            if (_cardModel.cardSuitValue.suit == CardSuit.Diamonds || _cardModel.cardSuitValue.suit == CardSuit.Hearts)
                _image.color = Color.red;
            else
                _image.color = Color.black;

            cardValueTxt.text = _cardModel.cardSuitValue.value.ToString();
            cardSuitTxt.text = _cardModel.cardSuitValue.suit.ToString();
        }     
    }

    public void OnBeginDrag(PointerEventData eventData)
    {     
        _cardListener?.OnBeginDragCard(eventData, this);       
    }

    public void OnDrag(PointerEventData eventData)
    {       
        _cardListener?.OnDragCard(eventData, this);       
    }

    public void OnEndDrag(PointerEventData eventData)
    {   
        _cardListener?.OnEndDragCard(eventData, this);
    }

    public void SetReverse(bool reverse)
    {
        _reverse = reverse;   
        UpdateCardInfo();
    }   
}


