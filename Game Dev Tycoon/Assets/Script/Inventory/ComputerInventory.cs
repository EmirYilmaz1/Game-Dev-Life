using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerInventory : MonoBehaviour
{
    [SerializeField] RectTransform ownedComputerTemplate;

     
    List<RectTransform> currentOwnedItem = new List<RectTransform>();
    SpawnComputer spawnComputer;
    OwnedItems ownedItems;
    int currentIndex;
    private void OnEnable() 
    {
        if(ownedItems == null) return;
        SetList();
        Debug.Log("u");
    }

    void Awake()
    {
        ownedItems = FindObjectOfType<OwnedItems>();
        spawnComputer = FindObjectOfType<SpawnComputer>();
        SetList();
        print("uuu");
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
        foreach(ComputerType computer in ownedItems.CheckOwnedComputer())
        {
            RectTransform ownedComputer = Instantiate(ownedComputerTemplate,transform);
            ownedComputer.anchoredPosition = new Vector2(0, ownedComputer.position.y+(+currentIndex*ownedComputerTemplate.sizeDelta.y+45));
            ownedComputer.Find("Name").GetComponent<TextMeshProUGUI>().text = computer.name;
            ownedComputer.Find("Image").GetComponent<Image>().sprite = computer.computerSprite;
            ownedComputer.Find("Button").GetComponent<Button>().onClick.AddListener(() =>spawnComputer.SpawnTheRecentComputer(computer.computer));
            currentOwnedItem.Add(ownedComputer);
            currentIndex++;
        }
    }
}
