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
    private IDoubleTapListener _listener;

    private void Awake()
    {
        _pointerEventData = new PointerEventData(EventSystem.current);
        _raycastResults = new List<RaycastResult>();
    }

    public void Setup(IDoubleTapListener listener)
    {
        _listener = listener;
    }

    void Update()
    {
        if (_listener == null)
            return;  

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
                _listener?.OnDoubleTap(cardview);
                break;
            }
        }
    }
}

public interface IDoubleTapListener
{
    void OnDoubleTap(CardView card);
}