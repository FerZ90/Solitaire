public class CardTranslator : IObserver<CardAnimatorObserverModel>
{
    private ICardAnimator _cardAnimator;

    public CardTranslator(ICardAnimator cardAnimator)
    {
        _cardAnimator = cardAnimator;
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
            InsertCard(card);
        }
    }

    public void MoveCard(IPile deck, CardView cardView)
    {
        ChangeCardDeck(deck, cardView);
        _cardAnimator.AnimateCardToPosition(cardView, cardView.CardModel.deck.GetNewCardPosition(cardView));
    }

    private void ChangeCardDeck(IPile newDeck, CardView cardView)
    {
        var newCardDeck = newDeck;

        if (newCardDeck == null)
            newCardDeck = cardView.CardModel.deck;

        if (cardView.CardModel.deck != newDeck)
            cardView.CardModel.deck = newCardDeck;

    }

    private void InsertCard(CardView cardView)
    {
        //cardView.CardModel.LogCard();

        //if (cardView.CardModel.deck == newDeck)
        //{
        //    cardView.CardModel.deck.ReturnCardToDeck(cardView);
        //}
        //else
        //{

        //    if (cardView.CardModel.deck != null)
        //        cardView.CardModel.deck.RemoveLast();

        //    cardView.CardModel.deck = newCardDeck;
        //    cardView.CardModel.deck.AddLast(cardView);
        //}
    }
}
