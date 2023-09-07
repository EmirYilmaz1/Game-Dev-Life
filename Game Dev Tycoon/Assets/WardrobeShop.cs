using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeShop : MonoBehaviour
{
   [SerializeField] RectTransform wardrobeTemplate;
   [SerializeField] List<WardrobeTypes> wardrobeDidntbought = new List<WardrobeTypes>();
    List<RectTransform> currentWardrobe = new List<RectTransform>();

    MoneyManager moneyManager;
    OwnedItems ownedItems;
    int currentIndex;

    private void OnEnable() 
    {
        if(ownedItems==null) return;


    }

    void Awake()
    {
        ownedItems = FindObjectOfType<OwnedItems>();
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    public void SetList()
    {
        currentIndex  = 0;
        if(currentWardrobe.Count>0)
        {
            foreach(RectTransform deletedShopItems in currentWardrobe)
            {
                Destroy(deletedShopItems.gameObject);
            }
        }

        foreach(WardrobeTypes alreadyOwned in ownedItems.CheckOwnedWardrobe())
        {
            if(wardrobeDidntbought.Contains(alreadyOwned))
            {
              wardrobeDidntbought.Remove(alreadyOwned);   
            }
        }

        foreach(WardrobeTypes wardrobe in wardrobeDidntbought)
        {
            RectTransform wardrobeClone = Instantiate(wardrobeTemplate,transform.position,Quaternion.identity,transform);
            wardrobeClone.anchoredPosition = new Vector2(0, wardrobeClone.position.y+(-currentIndex*(wardrobeClone.sizeDelta.y+45)));
            currentWardrobe.Add(wardrobeClone);
            currentIndex++;
        }
    }

}


public class SetWardrobeInfo
{
    public void SetInfo(RectTransform rectTransform, WardrobeTypes wardrobeTypes, MoneyManager moneyManager, OwnedItems ownedItems, WardrobeShop wardrobeShop)
    {
        rectTransform.Find("Image").GetComponent<Image>().sprite = wardrobeTypes.wardrobeImage;
        rectTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = wardrobeTypes.wardrobeName;
        rectTransform.Find("Cost").GetComponent<TextMeshProUGUI>().text = $"Cost: {wardrobeTypes.cost}";
        rectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => CanAfford(moneyManager,wardrobeTypes.cost, ownedItems, wardrobeTypes,wardrobeShop));
    }

    private void CanAfford(MoneyManager moneyManager, int cost, OwnedItems ownedItems, WardrobeTypes wardrobeType, WardrobeShop wardrobeShop)
    {
        if(moneyManager.CanAfford(cost))
        {
            moneyManager.DecreaseMoney(cost);
            ownedItems.AddWardrobe(wardrobeType);
            wardrobeShop.SetList();      
        }
    }
}
