using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SuitData")]
public class SuitSO : ScriptableObject
{

    public List<Sprite> lockedSuits;
    public List<Sprite> unlockedSuits;

    public void AddSuit(Sprite sprite)
    {
        unlockedSuits.Add(sprite);
    }
    public void RemoveSuit(Sprite sprite)
    {
        lockedSuits.Remove(sprite);
    }
}
