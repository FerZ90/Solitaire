using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICroupier, IDoubleTapListener, IObserver<List<CardView>>
{
    private DeckModel _deckModel; 

    public Croupier(ICardsObjectCreator cardsCreator, DeckModel deckModel)
    {
        _deckModel = deckModel;
        cardsCreator.CardsObjectCreatorObserver.Subscribe(this);
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

                    ChangeCardDeck(inGameDeck, card);
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


    public async void UpdateEvent(List<CardView> parameter)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in parameter)
        {
            ChangeCardDeck(_deckModel.deliveryDeck, cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        DealCards();
    }
  
   
    public void InsertIntoDeck(IPile deck, CardView cardView)
    {
        ChangeCardDeck(deck, cardView);      
    }

    public async void DeliverCard(CardView cardView)
    {
        if (cardView == null)
        {
            var lastCard = _deckModel.discardDeck.GetLast();

            while (lastCard != null)
            {
                ChangeCardDeck(_deckModel.deliveryDeck, lastCard);
                lastCard = _deckModel.discardDeck.GetLast();
                await Task.Delay(7);
            }
        }
        else
        {
            ChangeCardDeck(_deckModel.discardDeck, cardView);
        }       
    }

    private void ChangeCardDeck(IPile newDeck, CardView cardView)
    {
        var newCardDeck = newDeck;

        if (newCardDeck == null)
            newCardDeck = cardView.CardModel.deck;

        cardView.CardModel.LogCard();

        if (cardView.CardModel.deck == newDeck)
        {
            cardView.CardModel.deck.ReturnCardToDeck(cardView);
        }
        else
        {

            if (cardView.CardModel.deck != null)
                cardView.CardModel.deck.RemoveLast();

            cardView.CardModel.deck = newCardDeck;
            cardView.CardModel.deck.AddLast(cardView);
        }
    }

    public void OnDoubleTap(CardView card)
    {
        if (card.CardModel.deck is FinishedDeck || card.Reverse)
            return;

        if (card != null)
        {
            foreach (var finishedDeck in _deckModel.finishedDecks)
            {
                if (finishedDeck.TryInsertCard(card))
                {
                    ChangeCardDeck(finishedDeck, card);
                    break;
                }
            }
        }
    }

    #region OLD
    //public async void CompleteInGameDeck(List<CardView> completeDeck)
    //{
    //    for (int i = _deckModel.finishedDecks.Count - 1; i >= 0; i--)
    //    {
    //        var finishedDeck = _deckModel.finishedDecks[i];

    //        if (finishedDeck.IsComplete)
    //            continue;

    //        foreach (var card in completeDeck)
    //        {
    //            ChangeCardDeck(finishedDeck, card);
    //            await Task.Delay(100);
    //        }

    //        break;
    //    }

    //}
    #endregion
}

