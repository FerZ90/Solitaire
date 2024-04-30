using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public static class CardAnimator
{
    public static Task AnimateCardToPosition(CardView card, Vector3 to)
    {
        var task = card.GetComponent<RectTransform>().DOMove(to, 0.3f).AsyncWaitForCompletion();
        return task;
    }
  
}
