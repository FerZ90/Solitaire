using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    public int delaybetweenCards = 100;
    public float cardsAnimationTime = 0.3f;
}
