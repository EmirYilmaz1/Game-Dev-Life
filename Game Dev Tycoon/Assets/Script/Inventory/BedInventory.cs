using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BedInventory : MonoBehaviour
{
    [SerializeField] RectTransform ownedBedTemplate;

     
    List<RectTransform> currentOwnedItem = new List<RectTransform>();
    SpawnBed spawnBed;
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
        spawnBed = FindObjectOfType<SpawnBed>();
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
        foreach(BedType bed in ownedItems.CheckOwnedBed())
        {
            RectTransform ownedBed = Instantiate(ownedBedTemplate,transform);
            ownedBed.anchoredPosition = new Vector2(0, ownedBed.position.y+(+currentIndex*ownedBedTemplate.sizeDelta.y+45));
            ownedBed.Find("Name").GetComponent<TextMeshProUGUI>().text = bed.name;
            ownedBed.Find("Image").GetComponent<Image>().sprite = bed.bedImage;
            ownedBed.Find("Button").GetComponent<Button>().onClick.AddListener(() =>spawnBed.SpawnTheBed(bed));
            currentOwnedItem.Add(ownedBed);
            currentIndex++;
        }
    }
}
