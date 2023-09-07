using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BedShop : MonoBehaviour
{
    [SerializeField] List<BedType> bedsDidntBought = new List<BedType>();
    [SerializeField] RectTransform bedTemplate;
    
    List<RectTransform> currentItem = new List<RectTransform>();
    SpawnBed spawnBed;
    MoneyManager moneyManager;
    OwnedItems ownedItems;
    int currentIndex;

    private void OnEnable() 
    {
       if(ownedItems==null) return;

    }

    void Awake()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        ownedItems = FindObjectOfType<OwnedItems>();
        spawnBed = FindObjectOfType<SpawnBed>();
    }

    public void SetList()
    {
        currentIndex = 0;
        if(currentItem.Count>0)
        {
            foreach(RectTransform deleteButton in currentItem)
            {
                Destroy(deleteButton.gameObject);
            }
            currentItem.Clear();
        }

       foreach(BedType bed in bedsDidntBought)
       {
            if(ownedItems.CheckOwnedBed().Contains(bed))
            {
                bedsDidntBought.Remove(bed);
            }   
       } 
        SetBedInfo setBedInfo = new SetBedInfo();
        foreach(BedType beds in bedsDidntBought)
        {
            RectTransform bed = Instantiate(bedTemplate,transform.position, Quaternion.identity,transform);
            bed.anchoredPosition = new Vector2(0,bedTemplate.position.y+(-currentIndex*(bedTemplate.sizeDelta.y+45)));
            setBedInfo.SetBed(beds,spawnBed,bed,moneyManager,ownedItems,this);
            currentItem.Add(bed);
            currentIndex++;
        }
    }

    private void OnDisable() 
    {
        
    }
}

public class SetBedInfo
{
  public void SetBed(BedType bedType, SpawnBed spawnBed,RectTransform rectTransform, MoneyManager moneyManager, OwnedItems ownedItems,BedShop bedShop)
  {
    rectTransform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = bedType.bedImage;
    rectTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = bedType.bedName;
    rectTransform.Find("Cost").GetComponent<TextMeshProUGUI>().text = $"Cost: {bedType.cost}";
    rectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => CanAfford(moneyManager,spawnBed,bedType,bedType.cost, ownedItems,bedShop));
  }

  public void CanAfford(MoneyManager moneyManager, SpawnBed spawnBed, BedType bedType,int cost, OwnedItems ownedItems, BedShop bedShop)
  {
    if(moneyManager.CanAfford(cost))
    {
      ownedItems.AddBed(bedType);
      spawnBed.SpawnTheBed(bedType);
      moneyManager.DecreaseMoney(cost);
      bedShop.SetList();
    }
  }

}
