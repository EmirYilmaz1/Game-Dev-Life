using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillProgres :MonoBehaviour
{
    [SerializeField] TextMeshProUGUI notEnoughEnergy;
    [SerializeField] TextMeshProUGUI notEnoughMoney;
    [SerializeField] Skills skill;
    int energyCost = 30;


    PlayerStats playerStats;
    Energy energy;
    MoneyManager moneyManager;
    Button button;

    private int studyMoney;
    private int statLevel;

    bool canUpdate = true;

    private void OnEnable()
    {
        energy  = FindObjectOfType<Energy>();
        moneyManager = FindObjectOfType<MoneyManager>();

        FindSkill();
        SetSkill();
        transform.Find("Study Button").GetComponent<Button>().onClick.AddListener(() => CanStudy());
    }

    private void SetSkill()
    {
        studyMoney = statLevel *30;
        transform.Find("Energy").GetComponent<TextMeshProUGUI>().text =$"Energy: { energyCost}";
        transform.Find("Money").GetComponent<TextMeshProUGUI>().text = $"Money: {studyMoney}";
        transform.Find("Current Level").GetComponent<TextMeshProUGUI>().text =  $"Current Level {statLevel}";
    }

    public void ShowMoneyText()
    {
        StartCoroutine(NotEnouhMoney());
    }

    IEnumerator NotEnouhMoney()
    {
        notEnoughMoney.enabled = true;
       yield return new  WaitForSecondsRealtime(.3f);
       notEnoughMoney.enabled = false;
    }

    public void ShowEnergy()
    {
        StartCoroutine(NotEnergy());
    }

    IEnumerator NotEnergy()
    {
        notEnoughEnergy.enabled = true;
        yield return new WaitForSecondsRealtime(.3f);
        notEnoughEnergy.enabled = false;
    }

    private void FindSkill()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        switch (skill)
        {
            case Skills.programingSkill:
                statLevel = playerStats.programingSkill;
                break;

            case Skills.pixelDesignSkill:
                statLevel = playerStats.pixelDesignSkill;
                break;

            case Skills.gameDesignSkill:
                statLevel = playerStats.gameDesignSkill;
                break;

            case Skills.levelDesignSkill:
                statLevel = playerStats.levelDesignSkill;
                break;

            case Skills.markettingSkill:
                statLevel = playerStats.markettingSkill;
                break;
        }
    }

    public void CanStudy()
    {
        if(moneyManager.CanAfford(studyMoney) &&energy.CanAfford(energyCost) && canUpdate)
        {   
            canUpdate = false;
            playerStats.UpgradeSkill(skill);
            moneyManager.DecreaseMoney(studyMoney);
            energy.DecreaseEnergy(energyCost); 
            FindSkill();
            SetSkill();
            StartCoroutine(CanBuyTrue());
        }
        else if(!moneyManager.CanAfford(studyMoney))
        {
            ShowMoneyText();
        }
        else if(!energy.CanAfford(energyCost))
        {
            ShowEnergy();
        }
    }

    private IEnumerator CanBuyTrue()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        canUpdate = true;
    }
}
 
