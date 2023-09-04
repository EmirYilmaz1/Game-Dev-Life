using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skills{programingSkill, pixelDesignSkill, gameDesignSkill, levelDesignSkill, markettingSkill}
public class PlayerStats : MonoBehaviour
{
    public int programingSkill = 1;
    public int pixelDesignSkill = 1;
    public int gameDesignSkill = 1;
    public int levelDesignSkill = 1;
    public int markettingSkill = 1; // IncreaseSale

    public void UpgradeSkill(Skills skill)
    {
         switch (skill)
        {
            case Skills.programingSkill:
            programingSkill++;
            break;

            case Skills.pixelDesignSkill:
            pixelDesignSkill++;
            break;

            case Skills.gameDesignSkill:
            gameDesignSkill++;
            break;

            case Skills.levelDesignSkill:
            levelDesignSkill++;
            break;

            case Skills.markettingSkill:
            markettingSkill++;
            break;
        }
        Debug.Log("a");
    }

}




