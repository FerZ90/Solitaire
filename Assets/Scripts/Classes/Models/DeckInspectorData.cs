using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DeckInspectorData
{
    public Transform deliveryDeck;
    public Transform discardDeck;
    public List<Transform> inGameDecks = new List<Transform>();
    public List<Transform> finishedDecks = new List<Transform>();
}
