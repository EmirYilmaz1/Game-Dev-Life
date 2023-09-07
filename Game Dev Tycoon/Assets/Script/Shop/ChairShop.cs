using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChairShop : MonoBehaviour 
{
    [SerializeField] RectTransform chairButtonTemplate;
    [SerializeField] List<ChairType> chairDidntBought = new List<ChairType>();

    List<RectTransform> currentChair = new List<RectTransform>();
    SpawnChair spawnChair;
    MoneyManager moneyManager;
    OwnedItems ownedItems;
    int currentIndex;

    private void OnEnable() 
    {
        if(ownedItems == null) return;
        SetList();
    }

    private void Awake()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        ownedItems = FindObjectOfType<OwnedItems>();
        spawnChair = FindObjectOfType<SpawnChair>();

        SetList();
    }

    public void SetList()
    {
        if(currentChair.Count>0)
        {
            foreach(RectTransform deleteObject in currentChair)
            {
                Destroy(deleteObject.gameObject);
            }
            currentChair.Clear();
        }
            foreach(ChairType chairType in ownedItems.CheckOwnedChair())
            {
                if(chairDidntBought.Contains(chairType))
                {
                    chairDidntBought.Remove(chairType);
                }
            }

            currentIndex = 0;
            SetChairInfo setChairInfo = new SetChairInfo();
            foreach(ChairType chairs in chairDidntBought)
            {
               RectTransform chair = Instantiate(chairButtonTemplate,transform.position,Quaternion.identity,transform);
               chair.anchoredPosition = new Vector2(0, chair.position.y+(-currentIndex*(chair.sizeDelta.y+45)));
                setChairInfo.SetBed(chairs,spawnChair,chair,moneyManager,ownedItems,this);
               currentChair.Add(chair);
               currentIndex++;
            }

        
    }
}

public class SetChairInfo
{
  public void SetBed(ChairType chairType, SpawnChair spawnChair,RectTransform rectTransform, MoneyManager moneyManager, OwnedItems ownedItems,ChairShop chairShop)
  {
    rectTransform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = chairType.chairImage;
    rectTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = chairType.chairName;
    rectTransform.Find("Cost").GetComponent<TextMeshProUGUI>().text = $"Cost: {chairType.cost}";
    rectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => CanAfford(moneyManager,spawnChair,chairType,chairType.cost, ownedItems,chairShop));
  }

  public void CanAfford(MoneyManager moneyManager, SpawnChair spawnChair, ChairType chairType,int cost, OwnedItems ownedItems, ChairShop chairShop)
  {
    if(moneyManager.CanAfford(cost))
    {
      ownedItems.AddChair(chairType);
      spawnChair.SpawnTheChair(chairType);
      moneyManager.DecreaseMoney(cost);
      chairShop.SetList();
    }
  }

}