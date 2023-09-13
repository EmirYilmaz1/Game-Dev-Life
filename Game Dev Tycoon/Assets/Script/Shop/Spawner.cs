using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform starterFurniture;
    public FurnitureType furnitureType;

    Transform currentFurniture;

    void Start()
    {
       currentFurniture = Instantiate(starterFurniture, transform);
    }

   public void Spawn(Furniture furniture)
    {
        Destroy(currentFurniture.gameObject);
        currentFurniture = Instantiate(furniture.FurniturePrefab,transform);
    }

}
