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
     SetWork setWork = new SetWork();
     foreach(WorkTypes work in works)
     {
        Transform workContanier = Instantiate(workTemplate, gameObject.transform);
        setWork.SetInfo(workContanier, work, energy);
        currentIndex++;
     }

   }
}


public class SetWork
{
    public void SetInfo(Transform template,WorkTypes workType, Energy energy)
    {
        template.transform.Find("Image").GetComponent<Image>().sprite = workType.workImage;
        template.transform.Find("Work Name").GetComponent<TextMeshProUGUI>().text = workType.workName;
        template.transform.Find("Energy Cost").GetComponent<TextMeshProUGUI>().text = $" Energy Cost:{workType.EnergyAmount}";
        template.transform.Find("Work Button").GetComponent<Button>().onClick.AddListener(() => Work(energy,workType.EnergyAmount));
    }

    private void Work(Energy energy, float energyCost)
    {
        if(energy.CanAfford(energyCost))
        {
            energy.DecreaseEnergy(energyCost);
            GameManager.Instance.LoadTheScene();
        }
    }
}
