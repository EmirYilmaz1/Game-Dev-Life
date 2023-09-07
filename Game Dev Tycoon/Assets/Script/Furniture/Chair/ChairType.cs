using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Chair Type", menuName = "Chair Type")]
public class ChairType : ScriptableObject
{
    public Sprite chairImage;
    public string chairName;
    public Transform chairPrefab;
    public int cost;
}
