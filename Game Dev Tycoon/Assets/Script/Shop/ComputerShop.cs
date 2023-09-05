using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ComputerShop : MonoBehaviour
{
   
  [SerializeField] List<ComputerType> computersDidntBought = new List<ComputerType>();
  [SerializeField] RectTransform computerTemplate;
   

    List<RectTransform> currentComputers = new List<RectTransform>();
    MoneyManager moneyManager;
    SpawnComputer spawnComputer;
    OwnedItems ownedItems;
    int currentIndex;
  private void OnEnable()
    {
        if (computersDidntBought.Count <= 0) return;

        currentComputers = new List<RectTransform>();
        ownedItems = FindObjectOfType<OwnedItems>();
        moneyManager = FindObjectOfType<MoneyManager>();
        spawnComputer = FindObjectOfType<SpawnComputer>();

        SetComputerInf setComputerInfo = new SetComputerInf();
        SetList(setComputerInfo);

    }

    public void SetList(SetComputerInf setComputerInf)
    {
        if(currentComputers.Count>0)
        {
          foreach(RectTransform currentComputer in currentComputers)
          {
            Destroy(currentComputer.gameObject);
          }
        }

        currentIndex = 0;
        Debug.Log("asas");
        foreach (ComputerType alreadyBoughtComputer in ownedItems.CheckOwnedComputer())
        {
            if (computersDidntBought.Contains(alreadyBoughtComputer))
            {
                computersDidntBought.Remove(alreadyBoughtComputer);
            }
        }

        foreach (ComputerType computer in computersDidntBought)
        {
            RectTransform computerType = Instantiate(computerTemplate, transform.position, Quaternion.identity, transform);
            computerType.anchoredPosition = new Vector2(0, computerTemplate.position.y + (-currentIndex * (computerTemplate.sizeDelta.y + 45)));
            currentComputers.Add(computerType);
            setComputerInf.SetComputer(computer, computerType, moneyManager, spawnComputer, ownedItems, this);
            currentIndex++;
        }
    }

}


public class SetComputerInf
{
  public void SetComputer(ComputerType computerType, RectTransform rectTransform, MoneyManager moneyManager, SpawnComputer spawnComputer, OwnedItems ownedItems, ComputerShop computerShop)
  {
    rectTransform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = computerType.computerSprite;
    rectTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = computerType.computerName;
    rectTransform.Find("Cost").GetComponent<TextMeshProUGUI>().text = $"Cost: {computerType.cost}";
    rectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => CanAfford(moneyManager,spawnComputer,computerType,computerType.cost, ownedItems, computerShop));
  }

  public void CanAfford(MoneyManager moneyManager, SpawnComputer spawnComputer, ComputerType computerType ,int cost, OwnedItems ownedItems, ComputerShop computerShop)
  {
          Debug.Log("saadsdas");
    if(moneyManager.CanAfford(cost))
    {
      ownedItems.AddComputer(computerType);
      spawnComputer.SpawnTheRecentComputer(computerType.computer);
      moneyManager.DecreaseMoney(cost);
      computerShop.SetList(this);
    }
  }

}
