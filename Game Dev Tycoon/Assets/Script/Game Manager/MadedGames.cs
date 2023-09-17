using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MadedGames : MonoBehaviour
{
   public static List<GameType> gameTypes = new List<GameType>();
    public static void AddedGameObject(GameType gameType)
    {
        gameTypes.Add(gameType);
    }
    
}
