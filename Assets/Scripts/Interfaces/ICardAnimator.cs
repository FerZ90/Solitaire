using System.Threading.Tasks;
using UnityEngine;

public interface ICardAnimator
{
    public Task AnimateCardToPosition(CardView card, Vector3 to);
}
