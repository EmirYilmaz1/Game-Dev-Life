using UnityEngine;

public interface IFurnitures
{
   public Sprite FurnitureImage{get;}
   public Transform FurniturePrefab{get;}
   public string FurnitureName{get;}
   public int Cost{get;}
   public FurnitureType FurnitureType{get;}
}

public enum FurnitureType{chair, rug, wardrobe, computer, bed}
