using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkGenerator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
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
        setWork.SetInfo(workContanier, work, energy,moneyManager, this);
        workContanier.anchoredPosition = new Vector2(0, workTemplate.transform.position.y+(-currentIndex*(workContanier.sizeDelta.y +45)));
        currentIndex++;
     }
   }

   public void ShowText()
   {
        StartCoroutine(NotEnoughEnergy());
   }

   public IEnumerator NotEnoughEnergy()
   {
        textMeshProUGUI.enabled = true;
        yield return new WaitForSeconds(0.5f);
        textMeshProUGUI.enabled = false;
   }
}


public class SetWork
{
    public void SetInfo(RectTransform template,WorkTypes workType, Energy energy, MoneyManager moneyManager, WorkGenerator workGenerator)
    {
        template.Find("Image").GetComponent<Image>().sprite = workType.workImage;
        template.Find("Work Name").GetComponent<TextMeshProUGUI>().text = workType.workName;
        template.Find("Money Earn").GetComponent<TextMeshProUGUI>().text = $"Money: {workType.moneyGive}";
        template.Find("Energy Cost").GetComponent<TextMeshProUGUI>().text = $" Energy Cost:{workType.EnergyAmount}";
        template.Find("Work Button").GetComponent<Button>().onClick.AddListener(() => Work(energy,workType.EnergyAmount,moneyManager, workType.moneyGive, workGenerator));
    }

    private void Work(Energy energy, float energyCost, MoneyManager moneyManager, int earnedMoney, WorkGenerator workGenerator)
    {
        if(energy.CanAfford(energyCost))
        {
            energy.DecreaseEnergy(energyCost);
            moneyManager.IncreaseMoney(earnedMoney);
            GameManager.Instance.LoadTheScene();
        }
        else
        {
          workGenerator.ShowText();
        }
    }
}
