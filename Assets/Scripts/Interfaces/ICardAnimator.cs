using System.Threading.Tasks;
using UnityEngine;

public interface ICardAnimator
{
    public Task<bool> AnimateCardToPosition(Vector3 from, Vector3 to);
    public Task<bool> ReverseCard();

}
