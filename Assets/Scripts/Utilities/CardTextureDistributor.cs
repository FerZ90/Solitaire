using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardTextureDistributor", menuName = "ScriptableObjects/CardTextureDistributor", order = 2)]
public class CardTextureDistributor : ScriptableObject
{
    [SerializeField] private Sprite[] Backgrounds;
    [SerializeField] private Sprite[] Spades;
    [SerializeField] private Sprite[] Clovers;
    [SerializeField] private Sprite[] Hearts;
    [SerializeField] private Sprite[] Diamonds; 

    public Sprite GetRandomBackground()
    {
        System.Random random = new System.Random();
        int index = random.Next(0, Backgrounds.Length);
        return Backgrounds[index];
    }

    public Sprite GetCardTexture(CardInfo cardInfo)
    {
        switch (cardInfo.suit)
        {
            case CardSuit.Spades:
                return Spades[(int)cardInfo.value];
            case CardSuit.Clovers:
                return Clovers[(int)cardInfo.value];
            case CardSuit.Hearts:
                return Hearts[(int)cardInfo.value];
            case CardSuit.Diamonds:
                return Diamonds[(int)cardInfo.value];
            default:
                break;
        }

        return null;
    }

}
