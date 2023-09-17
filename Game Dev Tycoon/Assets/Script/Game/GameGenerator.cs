using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameGenerator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI notenoughskill;
    [SerializeField] RectTransform gameTemplate;
    [SerializeField] List<GameType> gameTypes = new List<GameType>();

    List<RectTransform> currentGame = new List<RectTransform>();
    MoneyManager moneyManager;
    PlayerStats playerStats;

    int currentIndex;
    void OnEnable()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        Setlist();
    }

    public void Setlist()
    {
        if(currentGame.Count>0)
        {
            foreach(RectTransform rectTransform in currentGame)
            {
                Destroy(rectTransform.gameObject);
            }
            currentGame = new List<RectTransform>();
        }
        currentIndex = 0;

        SetInfo setInfo = new SetInfo();
        foreach (GameType games in gameTypes)
        {
            if (MadedGames.gameTypes.Contains(games))
                continue;

            RectTransform gameContainer = Instantiate(gameTemplate, transform.position, Quaternion.identity, transform);
            setInfo.SetGame(gameContainer, games, playerStats, moneyManager, this);
            gameContainer.anchoredPosition = new Vector2(0, gameContainer.anchoredPosition.y + (-currentIndex * (gameContainer.sizeDelta.y + 45)) - 300);
            currentGame.Add(gameContainer);
            currentIndex++;
        }
    }

    public void ShowNotEnoughSkillMessage()
    {
        notenoughskill.gameObject.SetActive(true);
        StartCoroutine(HideNotEnoughSkillMessage());
    }

    private IEnumerator HideNotEnoughSkillMessage()
    {
        yield return new WaitForSeconds(0.5F);
        notenoughskill.gameObject.SetActive(false);
    }
}


public class SetInfo
{
    bool skill1 = true;
    bool skill2 = true;
    bool skill3 = true;
    string skillName;
    public void SetGame(RectTransform template,GameType gameType, PlayerStats playerStats, MoneyManager moneyManager, GameGenerator gameGenerator)
    {
        skill1 = true;
        skill2 = true;
        skill3 = true;
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
           }
        }
        template.Find("Money").GetComponent<TextMeshProUGUI>().text = $"Will Earn: {gameType.earnedMoney}";
        template.Find("Button").GetComponent<Button>().onClick.AddListener(() =>CanGameOkay(gameType,playerStats,moneyManager, gameGenerator));

    }

    public bool CanGameOkay(GameType gameType, PlayerStats playerStats, MoneyManager moneyManager, GameGenerator gameGenerator)
    {
        if (gameType.CanSkillAfford(playerStats))
        {
            int amount = Mathf.RoundToInt(gameType.earnedMoney + (gameType.earnedMoney * (playerStats.markettingSkill * 0.10f)));
            moneyManager.IncreaseMoney(amount);
            MadedGames.AddedGameObject(gameType);
            gameGenerator.Setlist();
            return true;
        }
        else
        {
            // Yetenek yetersizliği mesajını göster
            gameGenerator.ShowNotEnoughSkillMessage();
            return false;
        }
    }
}

