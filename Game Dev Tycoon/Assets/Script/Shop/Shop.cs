using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] FurnitureType furnitureType; 
    [SerializeField]  RectTransform shopTemplate;
    [SerializeField]  List<Furniture> itemDidntBought;

    List<RectTransform> currentItem = new List<RectTransform>();
    MoneyManager moneyManager;
    OwnedItems ownedItems;

    void Awake()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        ownedItems = FindObjectOfType<OwnedItems>();
    }

    void OnEnable()
    {
        SetList();
    }

    public void SetList()
    {   
        if(currentItem.Count>0)
        {
            foreach(RectTransform deleted in currentItem)
            {
             Destroy(deleted.gameObject);
            }
            currentItem = new List<RectTransform>();
        }


        List<Furniture> buyableItems = new List<Furniture>(); 
        foreach(Furniture furnitures in ownedItems.ownedItem)
        {
            if(furnitures.FurnitureType == furnitureType)
            {
                buyableItems.Add(furnitures);
            }
        }

        foreach(Furniture furniture in buyableItems)
        {
            if(itemDidntBought.Contains(furniture))
            {
                itemDidntBought.Remove(furniture);
            }
        }
        SetFurnitureInfo setFurnitureInfo = new SetFurnitureInfo();
        for (int i = 0; i < itemDidntBought.Count; i++)
        {
            RectTransform shopItem = Instantiate(shopTemplate, transform.position,Quaternion.identity,transform);
            setFurnitureInfo.SetInfo(shopItem,itemDidntBought[i],ownedItems,moneyManager, this);
            shopItem.anchoredPosition = new Vector2(0, shopItem.position.y+(-i*(shopItem.sizeDelta.y+45)));
            currentItem.Add(shopItem);
        }
    } 

    void OnDisable()
    {
        if(currentItem.Count<0) return;

        foreach(RectTransform deleted in currentItem)
        {
            print("aaa");
            Destroy(deleted.gameObject);
        }
        currentItem = new List<RectTransform>();
    }

}
