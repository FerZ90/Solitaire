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

    public void OnAnimationStart(CardView card)
    {
        blockerImage.enabled = true;
    }

    public void OnAnimationEnd(CardView card)
    {
        blockerImage.enabled = false;
    }
}





