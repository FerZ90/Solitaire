using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleTap : MonoBehaviour
{
    public float doubleTapTimeThreshold = 0.2f;
    private float lastTapTime;
    private float firstTapTime;
    private bool hasFirstTap;
    private PointerEventData _pointerEventData;
    private List<RaycastResult> _raycastResults;

    public Observer<DoubleTapObserverModel> Observer { get; private set; } = new Observer<DoubleTapObserverModel>();

    private void Awake()
    {
        _pointerEventData = new PointerEventData(EventSystem.current);
        _raycastResults = new List<RaycastResult>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (hasFirstTap && Time.time - lastTapTime > doubleTapTimeThreshold)
            {
                hasFirstTap = false;
            }

            if (!hasFirstTap)
            {
                hasFirstTap = true;
                firstTapTime = Time.time;
            }
            else
            {
                hasFirstTap = false;

                if (Time.time - firstTapTime <= doubleTapTimeThreshold)
                {
                    FindCardView();
                }

            }

            lastTapTime = Time.time;
        }
    }

    private void FindCardView()
    {
        _pointerEventData.position = Input.mousePosition;
        EventSystem.current.RaycastAll(_pointerEventData, _raycastResults);

        foreach (var result in _raycastResults)
        {
            if (result.gameObject.TryGetComponent<CardView>(out var cardview))
            {
                Observer.Notify(new DoubleTapObserverModel(cardview));
                break;
            }
        }
    }

}

public class DoubleTapObserverModel
{
    public CardView cardView;

    public DoubleTapObserverModel(CardView cardview)
    {
        this.cardView = cardview;
    }
}