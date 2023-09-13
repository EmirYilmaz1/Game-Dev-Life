using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    [SerializeField] FurnitureType furnitureType;
    [SerializeField] RectTransform inventoryTemplate;

    List<Furniture> ownedFurniture = new List<Furniture>();
    List<RectTransform> currentInventory = new List<RectTransform>();
    OwnedItems ownedItems;
    RectTransform Template;
    Spawner spawner;

    void Awake()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawners)
        {
            if(spawner.furnitureType == furnitureType)
            {
                this.spawner = spawner;
            }            
        }
        ownedItems = FindObjectOfType<OwnedItems>();      
    }

    void OnEnable()
    {
        SetList();
    }

    private void SetList()
    {
        foreach (Furniture wantedFurniture in ownedItems.ownedItem)
        {
            if (wantedFurniture.FurnitureType == furnitureType)
            {
                ownedFurniture.Add(wantedFurniture);
            }
        }
        SetInventoryInfo setInventoryInfo = new SetInventoryInfo();
        for (int i = 0; i < ownedFurniture.Count; i++)
        {
            RectTransform rectTransform = Instantiate(inventoryTemplate, transform.position, Quaternion.identity, transform);
            currentInventory.Add(rectTransform);
            rectTransform.anchoredPosition = new Vector2(0, (-transform.position.y+500) + rectTransform.position.y + (-i * (rectTransform.sizeDelta.y + 45)));
            setInventoryInfo.SetInventory(rectTransform, ownedFurniture[i], spawner );
        }
    }

    void OnDisable()
    {
        if(currentInventory.Count<0)return;

        foreach(RectTransform deleted in currentInventory)
        {
            Destroy(deleted.gameObject);
        }

        ownedFurniture.Clear();
        currentInventory = new List<RectTransform>();

    }
}
