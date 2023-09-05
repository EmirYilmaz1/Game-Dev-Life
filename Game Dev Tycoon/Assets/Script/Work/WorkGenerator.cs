using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkGenerator : MonoBehaviour
{

    [SerializeField] RectTransform workTemplate;
     [SerializeField] List<WorkTypes> works = new List<WorkTypes>();
    int currentIndex = 0;

   void Start()
   { 
     if(works.Count==0) return;

     currentIndex = 0;
     Energy energy = FindObjectOfType<Energy>();
     MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
     SetWork setWork = new SetWork();
     foreach(WorkTypes work in works)
     {
        RectTransform workContanier = Instantiate(workTemplate, transform.position,Quaternion.identity, gameObject.transform);
        setWork.SetInfo(workContanier, work, energy,moneyManager);
        workContanier.anchoredPosition = new Vector2(0, workTemplate.transform.position.y+(-currentIndex*(workContanier.sizeDelta.y +45)));
        currentIndex++;
     }

   }
}


public class SetWork
{
    public void SetInfo(RectTransform template,WorkTypes workType, Energy energy, MoneyManager moneyManager)
    {
        template.Find("Image").GetComponent<Image>().sprite = workType.workImage;
        template.Find("Work Name").GetComponent<TextMeshProUGUI>().text = workType.workName;
        template.Find("Money Earn").GetComponent<TextMeshProUGUI>().text = $"Money: {workType.moneyGive}";
        template.Find("Energy Cost").GetComponent<TextMeshProUGUI>().text = $" Energy Cost:{workType.EnergyAmount}";
        template.Find("Work Button").GetComponent<Button>().onClick.AddListener(() => Work(energy,workType.EnergyAmount,moneyManager, workType.moneyGive));
    }

    private void Work(Energy energy, float energyCost, MoneyManager moneyManager, int earnedMoney)
    {
        if(energy.CanAfford(energyCost))
        {
            energy.DecreaseEnergy(energyCost);
            moneyManager.IncreaseMoney(earnedMoney);
            GameManager.Instance.LoadTheScene();
        }
    }
}
