using System.Threading.Tasks;
using UnityEngine;

public class Croupier
{
    private IDecksController _deckController;

    public Croupier(IDecksController deckController)
    {
        _deckController = deckController;
    }

    public async void DealCards()
    {
        int count = 1;

        foreach (var inGameDeck in _deckController.GameDecks.inGameDecks)
        {
            for (int i = 0; i < count; i++)
            {
                var card = _deckController.GameDecks.deliveryDeck.RemoveLast();

                if (card != null)
                {
                    if (i == count - 1)
                       card.SetReverse(false);          
                    
                    _deckController.InsertIntoDeck(inGameDeck, card);
                }
                else
                {
                    Debug.LogError("DeliveryDeck is empty !!");
                }

                await Task.Delay(100);
            }

            count++;
        }
    }


}
