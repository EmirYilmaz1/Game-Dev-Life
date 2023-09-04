using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WorkGenerator : MonoBehaviour
{

    [SerializeField] Transform workTemplate;
     [SerializeField] List<WorkTypes> works = new List<WorkTypes>();
    int currentIndex = 0;

   void OnEnable()
   { 
     if(works.Count==0) return;

     currentIndex = 0;
     Energy energy = FindObjectOfType<Energy>();
     MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
     SetWork setWork = new SetWork();
     foreach(WorkTypes work in works)
     {
        Transform workContanier = Instantiate(workTemplate, gameObject.transform);
        setWork.SetInfo(workContanier, work, energy,moneyManager);
        currentIndex++;
     }

   }
}


public class SetWork
{
    public void SetInfo(Transform template,WorkTypes workType, Energy energy, MoneyManager moneyManager)
    {
        template.Find("Image").GetComponent<Image>().sprite = workType.workImage;
        template.Find("Work Name").GetComponent<TextMeshProUGUI>().text = workType.workName;
        template.Find("Money Earn").GetComponent<TextMeshProUGUI>().text = workType.moneyGive.ToString();
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
