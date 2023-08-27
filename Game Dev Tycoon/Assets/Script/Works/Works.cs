using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Works : MonoBehaviour
{
    [SerializeField] RectTransform workTemplate;
    [SerializeField] List<WorksTemplate> worksTemplate = new List<WorksTemplate>();
    int workNumber;
    string workName;
    int energyCost;
    int earnedMoney;
    private void OnEnable()
    {
        workNumber = 0;
       foreach(WorksTemplate works in worksTemplate)
       {
        workNumber++;
         RectTransform work = Instantiate(workTemplate, transform);
         SetWorks setWorks = new SetWorks();
         setWorks.SetInfo(work.gameObject, works, GameObject.FindGameObjectWithTag("Player"));
         work.anchoredPosition = new Vector2(0,-250*(workNumber-1));
       }
    }

}

public class SetWorks
{
    public void SetInfo(GameObject workContainer, WorksTemplate worksTemplate, GameObject player)
    {
        int energyCost = worksTemplate.energyCost;
        workContainer.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = worksTemplate.workName;
        workContainer.transform.Find("Energy").GetComponent<TextMeshProUGUI>().text = energyCost.ToString();
        workContainer.transform.Find("Cost").GetComponent<TextMeshProUGUI>().text = worksTemplate.earnedMoney.ToString();
        workContainer.transform.Find("Work").GetComponent<Button>().onClick.AddListener( () =>Worked(player, energyCost));
    }

    public void Worked(GameObject gameObject, int energyCost)
    {
        gameObject.GetComponent<Energy>().DecreaseEnergy(energyCost);
    }

}
