using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RugInventory : MonoBehaviour
{
    [SerializeField] RectTransform ownedRugTemplate;

     
    List<RectTransform> currentOwnedItem = new List<RectTransform>();
    ChangeRug spawnRug;
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
        spawnRug = FindObjectOfType<ChangeRug>();
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
        foreach(RugsType rug in ownedItems.CheckOwnedRugs())
        {
            RectTransform ownedRug = Instantiate(ownedRugTemplate,transform);
            ownedRug.anchoredPosition = new Vector2(0, ownedRug.position.y+(+currentIndex*ownedRugTemplate.sizeDelta.y+45));
            ownedRug.Find("Name").GetComponent<TextMeshProUGUI>().text = rug.rugName;
            ownedRug.Find("Image").GetComponent<Image>().sprite = rug.rugImage;
            ownedRug.Find("Button").GetComponent<Button>().onClick.AddListener(() =>spawnRug.NewRug(rug.rugMaterial));
            currentOwnedItem.Add(ownedRug);
            currentIndex++;
        }
    }
}
