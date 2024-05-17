public class CardTranslator : ICardTranslator, IObserver<CardAnimatorObserverModel>
{
    private ICardAnimator _cardAnimator;

    public CardTranslator(ICardAnimator cardAnimator)
    {
        _cardAnimator = cardAnimator;
        _cardAnimator.Observer.Subscribe(this);
    }

    public void UpdateEvent(CardAnimatorObserverModel parameter)
    {
        CardView card = parameter.card;

        if (!parameter.animationFinish)
        {
            card.transform.SetParent(card.transform.root);
            card.transform.SetAsLastSibling();
        }
        else
        {
            card.CardModel.deck.PutCardviewOnDeck(card);
        }
    }

    public void MoveCard(IPile deck, CardView cardView)
    {
        cardView.CardModel.LogCard();

        ChangeCardDeck(deck, cardView);
        _cardAnimator.AnimateCardToPosition(cardView, cardView.CardModel.deck.GetNewCardPosition(cardView));
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

public interface ICardTranslator
{
    void MoveCard(IPile deck, CardView cardView);
}
