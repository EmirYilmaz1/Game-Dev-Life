using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Furniture Type", menuName = "Furniture Type")]
public class Furniture : ScriptableObject, IFurnitures
{
   public Sprite furnitureImage;
   public Transform furniturePrefab;
   public string furnitureName;
   public FurnitureType furnitureType;
   public int cost;

    public Sprite FurnitureImage {get{return furnitureImage;}}

    public Transform FurniturePrefab{get{return furniturePrefab;}}

    public string FurnitureName{get{return furnitureName;}}

    public int Cost {get{return cost;}}

    public FurnitureType FurnitureType{get{return furnitureType;}}
}
