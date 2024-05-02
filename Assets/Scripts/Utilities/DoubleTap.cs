using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleTap : MonoBehaviour
{
    public float doubleTapTimeThreshold = 0.2f;
    private float lastTapTime;
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
        if (Input.GetMouseButtonUp(0))
        {
            if (!hasFirstTap)
            {
                hasFirstTap = true;
                lastTapTime = Time.time;
            }
            else
            {
                hasFirstTap = false;
                float timeSinceLastTap = Time.time - lastTapTime;

                if (timeSinceLastTap <= doubleTapTimeThreshold)
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
        }      
    }
}

public interface IDoubleTapListener
{
    void OnDoubleTap(CardView card);
}