using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICroupier
{
    private DeckModel _deckModel;
    private ICroupierListener _listener;

    public Croupier(ICroupierListener listener, DeckModel deckModel)
    {
        _listener = listener;
        _deckModel = deckModel;
    }

    public async void DealCards()
    {
        int count = 1;

        foreach (var inGameDeck in _deckModel.inGameDecks)
        {
            for (int i = 0; i < count; i++)
            {
                var card = _deckModel.deliveryDeck.GetLast();

                if (card != null)
                {
                    if (i == count - 1)
                        card.SetReverse(false);

                    _listener.MoveCard(inGameDeck, card);
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

    //public void UpdateEvent(CardMovementObserverModel parameter)
    //{
    //    if (parameter.deck is DeliveryPile)
    //    {
    //        DeliverCard(parameter.card);
    //    }
    //    else
    //    {
    //        _listener.MoveCard(parameter.deck, parameter.card);
    //    }
    //}


    //public async void UpdateEvent(CardsObjectCreatorObserverModel parameter)
    //{
    //    List<Task> allTasks = new List<Task>();

    //    foreach (var cardView in parameter.cardsViews)
    //    {
    //        _listener.MoveCard(_deckModel.deliveryDeck, cardView);
    //        allTasks.Add(Task.Delay(100));
    //    }

    //    await Task.WhenAll(allTasks);

    //    DealCards();
    //}


    public async void DeliverCard(CardView cardView)
    {
        if (cardView == null)
        {
            var lastCard = _deckModel.discardDeck.GetLast();

            while (lastCard != null)
            {
                _listener.MoveCard(_deckModel.deliveryDeck, lastCard);
                lastCard = _deckModel.discardDeck.GetLast();
                await Task.Delay(7);
            }
        }
        else
        {
            _listener.MoveCard(_deckModel.discardDeck, cardView);
        }
    }

}

public interface ICroupierListener
{
    void MoveCard(IPile deck, CardView card);

}


