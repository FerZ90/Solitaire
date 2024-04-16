using System.Threading.Tasks;

public class Croupier
{
    private IDecksController _deckController;

    public Croupier(IDecksController deckController)
    {
        _deckController = deckController;
    }

    public async void DealCards()
    {
        int count = 0;

        foreach (var inGameDeck in _deckController.GameDecks.inGameDecks)
        {
            for (int i = 0; i < count; i++)
            {
                var card = _deckController.GameDecks.deliveryDeck.GetLastCard();

                if (card != null)
                {
                    _deckController.InsertIntoDeck(inGameDeck, card);
                }

                await Task.Delay(100);
            }

            count++;
        }
    }


}
