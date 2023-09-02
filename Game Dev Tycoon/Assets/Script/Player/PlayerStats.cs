using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int programingSkill = 1;
    int pixelDesignSkill = 1;
    int gameDesignSkill = 1;
    int levelDesignSkill = 1;
    int markettingSkill = 1;
    int threeSkill = 1;

    Stats stats = new Stats();
    void Start()
    {

    }

}

public class Stats
{
    int programingSkill = 1;
    int pixelDesignSkill = 1;
    int gameDesignSkill = 1;
}
