using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Croupier : ICardsObjectCreatorListener, ICroupier
{
    private DeckModel _deckModel; 

    public Croupier(DeckModel deckModel)
    {
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

    public async void OnCreateCardsViews(List<CardView> cardViews)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in cardViews)
        {
            ChangeCardDeck(_deckModel.deliveryDeck, cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        DealCards();
    }
   
    public void InsertIntoDeck(IDeck deck, CardView cardView)
    {
        ChangeCardDeck(deck, cardView);      
    }

    public void DeliverCard(CardView cardView)
    {
        ChangeCardDeck(_deckModel.discardDeck, cardView);     
    }

    public async void CompleteInGameDeck(List<CardView> completeDeck)
    {
        for (int i = _deckModel.finishedDecks.Count - 1; i >= 0; i--)
        {
            var finishedDeck = _deckModel.finishedDecks[i];

            if (finishedDeck.IsComplete)
                continue;

            foreach (var card in completeDeck)
            {
                ChangeCardDeck(finishedDeck, card);
                await Task.Delay(100);
            }               

            break;
        }

       
    }

    private void ChangeCardDeck(IDeck newDeck, CardView cardView)
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
   
}

