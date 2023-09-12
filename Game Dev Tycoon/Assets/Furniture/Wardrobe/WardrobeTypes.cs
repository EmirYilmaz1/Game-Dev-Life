using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wardrobe Type", menuName = "Wardrobe")]
public class WardrobeTypes : ScriptableObject
{
    public Sprite wardrobeImage;
    public Transform wardrobePrefab;
    public string wardrobeName;
    public int cost;
}
