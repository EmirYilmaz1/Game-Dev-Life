using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Game Type", menuName = "Create Game Type")]
public class GameType : ScriptableObject
{
    public List<Skills> neededSkill = new List<Skills>();

    public string gameName;
    public int neededProgramingSkill;
    public int neededPixelDesignSkill;
    public int neededGameDesignSkill;
    public int neededLevelDesignSkill;
    public int neededMarkettingSkill;

    int moneyCost;
    int energyCost;
    public int earnedMoney;

    public bool didMade;

   public bool CanSkillAfford(PlayerStats playerStats)
    {
        foreach(Skills skill in neededSkill)
        {
            switch(skill)
            {
                case Skills.programingSkill:
                if(neededProgramingSkill > playerStats.programingSkill)
                {
                    return false;
                }
                break;

                case Skills.pixelDesignSkill:
                if(neededPixelDesignSkill>playerStats.pixelDesignSkill)
                {
                    return false;
                }
                break;

                case Skills.gameDesignSkill:
                if(neededGameDesignSkill>playerStats.gameDesignSkill)
                {
                    return false;
                }
                break;

                case Skills.levelDesignSkill:
                if(neededLevelDesignSkill>playerStats.levelDesignSkill)
                {
                    return false;
                }
                break;

                case Skills.markettingSkill:
                if(neededMarkettingSkill>playerStats.markettingSkill)
                {
                    return false;
                }
                break;

            }
        }
        return true;
    }
}
