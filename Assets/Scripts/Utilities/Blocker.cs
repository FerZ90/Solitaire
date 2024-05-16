using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Blocker : MonoBehaviour, ICardAnimatorListener
{
    private Image blockerImage;

    private void Awake()
    {
        blockerImage = GetComponent<Image>();
        blockerImage.enabled = false;
    }

    public void StartAnimation()
    {
        blockerImage.enabled = false;
    }

    public void FinishAnimation()
    {
        blockerImage.enabled = true;
    }
}



