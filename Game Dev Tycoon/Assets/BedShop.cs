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
    }

    void SetList()
    {
        currentIndex = 0;
        if(currentItem.Count>0)
        {
            foreach(RectTransform deleteButton in currentItem)
            {
                Destroy(deleteButton.gameObject);
            }
        }

       foreach(BedType bed in bedsDidntBought)
       {
            if(ownedItems.CheckOwnedBed().Contains(bed))
            {
                bedsDidntBought.Remove(bed);
            }   
       } 
        // SetBedInfo setBedInfo = new SetBedInfo();
        foreach(BedType beds in bedsDidntBought)
        {
            RectTransform bed = Instantiate(bedTemplate,transform.position, Quaternion.identity,transform);
            bed.anchoredPosition = new Vector2(0,bedTemplate.position.y+(-currentIndex*(bedTemplate.sizeDelta.y+45)));
            currentItem.Add(bed);
            currentIndex++;
        }
    }
}

// public class SetBedInfo
// {
//   public void SetComputer(BedType bedType, RectTransform rectTransform, MoneyManager moneyManager, OwnedItems ownedItems)
//   {
//     rectTransform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = bedType.bedImage;
//     rectTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = bedType.bedName;
//     rectTransform.Find("Cost").GetComponent<TextMeshProUGUI>().text = $"Cost: {bedType.cost}";
//     rectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => CanAfford(moneyManager,,computerType,computerType.cost, ownedItems, computerShop));
//   }

//   public void CanAfford(MoneyManager moneyManager, SpawnComputer spawnComputer, ComputerType computerType ,int cost, OwnedItems ownedItems)
//   {
//     if(moneyManager.CanAfford(cost))
//     {
//       ownedItems.AddComputer(computerType);
//       spawnComputer.SpawnTheRecentComputer(computerType.computer);
//       moneyManager.DecreaseMoney(cost);
//     }
//   }

// }
