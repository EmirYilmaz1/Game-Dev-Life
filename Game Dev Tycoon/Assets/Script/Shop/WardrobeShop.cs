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

    SpawnWardrobe spawnWardrobe;
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
        spawnWardrobe = FindObjectOfType<SpawnWardrobe>();
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
            currentWardrobe.Clear();
        }

        foreach(WardrobeTypes alreadyOwned in ownedItems.CheckOwnedWardrobe())
        {
            if(wardrobeDidntbought.Contains(alreadyOwned))
            {
              wardrobeDidntbought.Remove(alreadyOwned);   
            }
        }
        SetWardrobeInfo setWardrobeInfo= new SetWardrobeInfo();
        foreach(WardrobeTypes wardrobe in wardrobeDidntbought)
        {
            RectTransform wardrobeClone = Instantiate(wardrobeTemplate,transform.position,Quaternion.identity,transform);
            setWardrobeInfo.SetInfo(wardrobeClone,wardrobe,moneyManager,ownedItems,this,spawnWardrobe);
            wardrobeClone.anchoredPosition = new Vector2(0, wardrobeClone.position.y+(-currentIndex*(wardrobeClone.sizeDelta.y+45)));
            currentWardrobe.Add(wardrobeClone);
            currentIndex++;
        }
    }

}


public class SetWardrobeInfo
{
    public void SetInfo(RectTransform rectTransform, WardrobeTypes wardrobeTypes, MoneyManager moneyManager, OwnedItems ownedItems, WardrobeShop wardrobeShop, SpawnWardrobe spawnWardrobe)
    {
        rectTransform.Find("Image").GetComponent<Image>().sprite = wardrobeTypes.wardrobeImage;
        rectTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = wardrobeTypes.wardrobeName;
        rectTransform.Find("Cost").GetComponent<TextMeshProUGUI>().text = $"Cost: {wardrobeTypes.cost}";
        rectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => CanAfford(moneyManager,wardrobeTypes.cost, ownedItems, wardrobeTypes,wardrobeShop,spawnWardrobe));
    }

    private void CanAfford(MoneyManager moneyManager, int cost, OwnedItems ownedItems, WardrobeTypes wardrobeType, WardrobeShop wardrobeShop, SpawnWardrobe spawnWardrobe)
    {
        if(moneyManager.CanAfford(cost))
        {
            moneyManager.DecreaseMoney(cost);
            ownedItems.AddWardrobe(wardrobeType);
            spawnWardrobe.Spawner(wardrobeType);
            wardrobeShop.SetList();      
        }
    }
}
