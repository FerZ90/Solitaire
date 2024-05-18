using UnityEngine;
using UnityEngine.EventSystems;

public class CardTranslator : IUserInputHandlerListener
{
    private ICardTranslatorListener _listener;

    public CardTranslator(ICardTranslatorListener listener)
    {
        _listener = listener;
    }


    public void OnEndDragCard(IPile pile, CardView card, PointerEventData eventData)
    {
        MoveCard(pile, card);
    }

    public void OnDropCard(IPile pile, CardView card, PointerEventData eventData)
    {
        //
    }

    //public void UpdateEvent(CardAnimatorObserverModel parameter)
    //{
    //    CardView card = parameter.card;

    //    if (!parameter.animationFinish)
    //    {
    //        card.transform.SetParent(card.transform.root);
    //        card.transform.SetAsLastSibling();
    //    }
    //    else
    //    {
    //        card.CardModel.deck.PutCardviewOnDeck(card);
    //    }
    //}

    public void MoveCard(IPile deck, CardView cardView)
    {
        cardView.CardModel.LogCard();

        ChangeCardDeck(deck, cardView);
        _listener.AnimateCardToPosition(cardView, cardView.CardModel.deck.GetNewCardPosition(cardView));
    }

    private void ChangeCardDeck(IPile newDeck, CardView cardView)
    {
        var newCardDeck = newDeck;

        if (newCardDeck == null)
            newCardDeck = cardView.CardModel.deck;

        if (cardView.CardModel.deck != newCardDeck)
        {
            if (cardView.CardModel.deck != null)
                cardView.CardModel.deck.RemoveLast();

            cardView.CardModel.deck = newCardDeck;
            cardView.CardModel.deck.AddLast(cardView);
        }
    }

}


public interface ICardTranslatorListener
{
    void AnimateCardToPosition(CardView card, Vector3 to);
}

