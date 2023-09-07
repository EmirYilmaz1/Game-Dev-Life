using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bed Type", menuName = "Bed Type")]
public class BedType : ScriptableObject
{
   public Sprite bedImage;
   public Transform bedPrefab;
   public string bedName;
   public int cost;
   
}
