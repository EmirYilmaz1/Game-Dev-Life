using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillProgres :MonoBehaviour
{
    [SerializeField] Skills skill;
    [SerializeField] int energyCost;


    PlayerStats playerStats;
    Energy energy;
    MoneyManager moneyManager;
    Button button;

    private int studyMoney;
    private int statLevel;

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
        if(moneyManager.CanAfford(studyMoney) &&energy.CanAfford(energyCost))
        {
            moneyManager.DecreaseMoney(studyMoney);
            energy.DecreaseEnergy(energyCost);
            playerStats.UpgradeSkill(skill);
            FindSkill();
            SetSkill();
        }
        else
        {
            Debug.LogWarning("Man this is bad");        }
    }
}
 
