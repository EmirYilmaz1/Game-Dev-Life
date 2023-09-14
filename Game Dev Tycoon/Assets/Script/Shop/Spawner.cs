using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Spawner : MonoBehaviour
{
    public Spawner Instance;
    [SerializeField] Transform starterFurniture;
    public FurnitureType furnitureType;

    Transform currentFurniture;

    // static bool isChairSpawned;
    // static bool isRugSpawned;
    // static bool isWardrobeSpawned;
    // static bool isComputerSpawned;
    // static bool isBedSpawned;
    // static bool isTvSpawned;


    void Awake()
    { 
        currentFurniture = Instantiate(starterFurniture, transform);

         if(File.Exists((Application.persistentDataPath + "/save.txt")))
         {  
            string saveFile = File.ReadAllText(Application.persistentDataPath + "/save.txt");
            Json jsonSaveFile = JsonUtility.FromJson<Json>(saveFile);
            List<Furniture> furniture = jsonSaveFile.furnitureInScene;
             foreach(Furniture furniture1 in furniture)
            {
                if(furnitureType == furniture1.FurnitureType)
                {
                  Spawn(furniture1);
                  break;
                }
            }
         }
    }

   public void Spawn(Furniture furniture)
    {
        Destroy(currentFurniture.gameObject);
        currentFurniture = Instantiate(furniture.FurniturePrefab,transform);
    }

}
