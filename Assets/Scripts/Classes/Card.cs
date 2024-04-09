using System.Threading.Tasks;
using UnityEngine;

public class Card : MonoBehaviour, ICardAnimator
{
    private CardModel _cardModel;
    private bool _isInitialize;

    public void Initialize(CardModel cardModel)
    {
        _cardModel = cardModel;
    }

    public Task<bool> AnimateCardToPosition(Vector3 from, Vector3 to)
    {
        return Task.FromResult(true);
    }

    public Task<bool> ReverseCard()
    {
        return Task.FromResult(true);
    }
}
