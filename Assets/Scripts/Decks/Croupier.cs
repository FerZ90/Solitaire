using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : IUserInputHandlerListener, IDoubleTapListener, ICardsObjectCreatorListener, IDeliveryPileListener
{
    private DeckModel _deckModel;
    private ICroupierListener _listener;

    public Croupier(ICroupierListener listener, DeckModel deckModel)
    {
        _listener = listener;
        _deckModel = deckModel;
    }

    public async void DealFirstCards()
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

                    _listener.MoveCard(inGameDeck, card, MovementType.Croupier);
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

    public async void DeliverCard(CardView card)
    {
        if (card == null)
        {
            var lastCard = _deckModel.discardDeck.GetLast();

            while (lastCard != null)
            {
                _listener.MoveCard(_deckModel.deliveryDeck, lastCard, MovementType.Croupier);
                lastCard = _deckModel.discardDeck.GetLast();
                await Task.Delay(7);
            }
        }
        else
        {
            _listener.MoveCard(_deckModel.discardDeck, card, MovementType.Croupier);
        }
    }

    public async void OnCreateCards(List<CardView> cardsViews)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in cardsViews)
        {
            _listener.MoveCard(_deckModel.deliveryDeck, cardView, MovementType.Croupier);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);
        DealFirstCards();
    }

    public void OnDropCard(IPile pile, CardView card, MovementType movementType)
    {
        _listener.MoveCard(pile, card, movementType);
    }

    public void OnEndDragCard(IPile pile, CardView card, MovementType movementType)
    {
        _listener.MoveCard(pile, card, movementType);
    }

    public void OnDoubleTap(CardView card)
    {
        if (card.CardModel.deck is FinishedDeck || card.Reverse || card.CardModel.deck.GetLast() != card)
            return;

        if (card != null)
        {
            foreach (var finishedDeck in _deckModel.finishedDecks)
            {
                if (finishedDeck.TryInsertCard(card))
                {
                    _listener.MoveCard(finishedDeck, card, MovementType.User);
                    break;
                }
            }
        }
    }
}

public interface ICroupierListener
{
    void MoveCard(IPile deck, CardView card, MovementType movementType);

}


