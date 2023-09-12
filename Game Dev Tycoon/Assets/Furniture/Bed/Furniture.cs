using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Furniture Type", menuName = "Furniture Type")]
public class Furniture : ScriptableObject, IFurnitures
{
   public Sprite bedImage;
   public Transform bedPrefab;
   public string bedName;
   public FurnitureType furnitureType;
   public int cost;

    public Sprite FurnitureImage {get{return bedImage;}}

    public Transform FurniturePrefab{get{return bedPrefab;}}

    public string FurnitureName{get{return bedName;}}

    public int Cost {get{return cost;}}

    public FurnitureType FurnitureType{get{return furnitureType;}}
}
