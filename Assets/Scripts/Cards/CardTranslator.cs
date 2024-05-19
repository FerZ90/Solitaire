using UnityEngine;

public class CardTranslator : IUserInputHandlerListener, ICroupierListener, ICardAnimatorListener
{
    private ICardTranslatorListener _listener;

    public CardTranslator(ICardTranslatorListener listener)
    {
        _listener = listener;
    }

    public void OnEndDragCard(IPile pile, CardView card, MovementType movementType)
    {
        MoveCard(pile, card, movementType);
    }

    public void OnDropCard(IPile pile, CardView card, MovementType movementType)
    {
        //
    }

    public void OnAnimationStart(CardView card)
    {
        card.transform.SetParent(card.transform.root);
        card.transform.SetAsLastSibling();
    }

    public void OnAnimationEnd(CardView card)
    {
        card.CardModel.deck.PutCardviewOnDeck(card);
    }

    public void MoveCard(IPile deck, CardView cardView, MovementType movementType)
    {
        cardView.CardModel.LogCard();

        ChangeCardDeck(deck, cardView, movementType);
        _listener?.AnimateCardToPosition(cardView, cardView.CardModel.deck.GetNewCardPosition(cardView));
    }

    private void ChangeCardDeck(IPile newDeck, CardView cardView, MovementType movementType)
    {
        var newCardDeck = newDeck;

        if (newCardDeck == null)
            newCardDeck = cardView.CardModel.deck;

        if (cardView.CardModel.deck != newCardDeck)
        {
            if (cardView.CardModel.deck != null)
                cardView.CardModel.deck.RemoveLast();

            cardView.CardModel.deck = newCardDeck;
            cardView.CardModel.deck.AddLast(cardView, movementType);
        }
    }

}


public interface ICardTranslatorListener
{
    void AnimateCardToPosition(CardView card, Vector3 to);
}

public enum MovementType
{
    User,
    Croupier
}

