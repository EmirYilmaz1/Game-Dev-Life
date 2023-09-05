using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameGenerator : MonoBehaviour
{
    [SerializeField] RectTransform gameTemplate;
    [SerializeField] List<GameType> gameTypes = new List<GameType>();
    MoneyManager moneyManager;
    PlayerStats playerStats;

    int currentIndex;
    void OnEnable()
    {
        currentIndex = 0;
        moneyManager = FindObjectOfType<MoneyManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        SetInfo setInfo = new SetInfo();
       foreach(GameType games in gameTypes)
       {
            RectTransform gameContainer = Instantiate(gameTemplate,transform.position,Quaternion.identity,transform);
            setInfo.SetGame(gameContainer, games, playerStats,moneyManager);
            gameContainer.anchoredPosition = new Vector2(0,gameContainer.anchoredPosition.y+(-currentIndex*(gameContainer.sizeDelta.y+45)));
            currentIndex++;
       } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class SetInfo
{
    bool skill1 = true;
    bool skill2 = true;
    bool skill3 = true;
    string skillName;
    public void SetGame(RectTransform template,GameType gameType, PlayerStats playerStats, MoneyManager moneyManager)
    {
        template.Find("Name").GetComponent<TextMeshProUGUI>().text = gameType.gameName;
        foreach(Skills skill in gameType.neededSkill)
        {
            
            int requiredLevel = 0;
           switch(skill)
           {
                case Skills.programingSkill:
                    skillName = "Programing";
                    requiredLevel = gameType.neededProgramingSkill;
                break;

                case Skills.pixelDesignSkill:
                    skillName = "Pixel Art";
                    requiredLevel = gameType.neededPixelDesignSkill;
                break;

                case Skills.gameDesignSkill:
                    skillName = "Game Design";
                    requiredLevel = gameType.neededGameDesignSkill;
                break;

                case Skills.levelDesignSkill:
                    skillName = "Level Design";
                    requiredLevel = gameType.neededLevelDesignSkill;
                break;

                case Skills.markettingSkill:
                    skillName = "Marketing";
                    requiredLevel = gameType.neededMarkettingSkill;
                break;
           }

           if(skill1)
           {
            skill1 = false;
            template.Find("Skill 1").GetComponent<TextMeshProUGUI>().text = $"{skillName}: {requiredLevel}";
           }else if(skill2)
           {
            skill2 = false;
            template.Find("Skill 2").GetComponent<TextMeshProUGUI>().text = $"{skillName}: {requiredLevel}";
           }
           else if(skill3)
           {
            skill3 = false;
                template.Find("Skill 3").GetComponent<TextMeshProUGUI>().text = $"{skillName}: {requiredLevel}";
                Debug.Log("aaaa");
           }
        }

        template.Find("Button").GetComponent<Button>().onClick.AddListener(() =>CanGameOkay(gameType,playerStats,moneyManager));

    }

    public bool CanGameOkay(GameType gameType, PlayerStats playerStats, MoneyManager moneyManager)
    {
        if(gameType.CanSkillAfford(playerStats))
        {
            int amount = Mathf.RoundToInt(gameType.earnedMoney + (gameType.earnedMoney * (playerStats.markettingSkill * 0.10f)));
            moneyManager.IncreaseMoney(amount);
            Debug.Log("uuuu");
            return true;
        }
        Debug.Log("aaaa");
        return false;
    }
}

