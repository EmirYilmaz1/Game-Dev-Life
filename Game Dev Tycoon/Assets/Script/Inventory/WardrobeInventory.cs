using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeInventory : MonoBehaviour
{
    [SerializeField] RectTransform ownedWardrobeTemplate;

     
    List<RectTransform> currentOwnedItem = new List<RectTransform>();
    SpawnWardrobe spawnWardrobe;
    OwnedItems ownedItems;
    int currentIndex;
    private void OnEnable() 
    {
        if(ownedItems == null) return;
        SetList();
    }

    void Awake()
    {
        ownedItems = FindObjectOfType<OwnedItems>();
        spawnWardrobe = FindObjectOfType<SpawnWardrobe>();
        SetList();
    }

    public void SetList()
    {
        if(currentOwnedItem.Count>0)
        {
            foreach(RectTransform delete in currentOwnedItem)
            {
                Destroy(delete.gameObject);
            }
            currentOwnedItem.Clear();
        }


        currentIndex = 0;
        foreach(WardrobeTypes wardrobe in ownedItems.CheckOwnedWardrobe())
        {
            RectTransform ownedRug = Instantiate(ownedWardrobeTemplate,transform);
            ownedRug.anchoredPosition = new Vector2(0, ownedRug.position.y+(+currentIndex*ownedWardrobeTemplate.sizeDelta.y+45));
            ownedRug.Find("Name").GetComponent<TextMeshProUGUI>().text = wardrobe.wardrobeName;
            ownedRug.Find("Image").GetComponent<Image>().sprite = wardrobe.wardrobeImage;
            ownedRug.Find("Button").GetComponent<Button>().onClick.AddListener(() =>spawnWardrobe.Spawner(wardrobe));
            currentOwnedItem.Add(ownedRug);
            currentIndex++;
        }
    }
}
