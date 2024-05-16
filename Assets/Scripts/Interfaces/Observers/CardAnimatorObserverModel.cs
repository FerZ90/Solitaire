public struct CardAnimatorObserverModel
{
    public CardView card;
    public bool animationFinish;

    public CardAnimatorObserverModel(CardView card, bool animationFinish)
    {
        this.card = card;
        this.animationFinish = animationFinish;
    }
}
