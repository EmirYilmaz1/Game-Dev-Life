using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);        
    }
    void Start()
    {
        if(File.Exists((Application.persistentDataPath + "/save.txt")))
        Load();


    }

   public void LoadTheScene()
    {
       Fade fade = FindObjectOfType<Fade>();
       StartCoroutine(LoacScene(1,2,fade));
    }

    public IEnumerator LoacScene(float fadeOutTime, float fadeInTime, Fade fade)
    {
        Save();
        StartCoroutine(fade.FadeOut(fadeOutTime));
        yield return new WaitForSecondsRealtime(fadeOutTime);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    private void Save()
    {
        Json jsonSaveFile = new Json();
        Types[] objectInTheScene = FindObjectsOfType<Types>();
        foreach (var furniture in objectInTheScene)
        {
            jsonSaveFile.furnitureInScene.Add(furniture.GetFurniture());
        }
        PlayerStats  playerStats = FindObjectOfType<PlayerStats>();
        jsonSaveFile.programingSkill = playerStats.programingSkill;
        jsonSaveFile.pixelDesignSkill = playerStats.pixelDesignSkill;
        jsonSaveFile.gameDesignSkill = playerStats.gameDesignSkill;
        jsonSaveFile.levelDesignSkill = playerStats.levelDesignSkill;
        jsonSaveFile.markettingSkill = playerStats.markettingSkill;
        jsonSaveFile.gameTypes = MadedGames.gameTypes;
        jsonSaveFile.money = FindObjectOfType<MoneyManager>().GetCurrentMoney();
        jsonSaveFile.ownedItems = FindObjectOfType<OwnedItems>().ownedItem;

        string jsonFile = JsonUtility.ToJson(jsonSaveFile);
       File.WriteAllText(Application.persistentDataPath+"/save.txt", jsonFile);
    }
    
    public void Load()
    {
        string saveFile = File.ReadAllText(Application.persistentDataPath + "/save.txt");
        Json jsonSaveFile = JsonUtility.FromJson<Json>(saveFile);

        List<Furniture> furniture = jsonSaveFile.furnitureInScene;
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (var item in spawners)
        {
            foreach(Furniture furniture1 in furniture)
            {
                if(item.furnitureType == furniture1.FurnitureType)
                {
                    item.Spawn(furniture1);
                }
            }
        }

        PlayerStats playerStats =  FindObjectOfType<PlayerStats>();
        playerStats.programingSkill = jsonSaveFile.programingSkill;
        playerStats.pixelDesignSkill = jsonSaveFile.pixelDesignSkill;
        playerStats.gameDesignSkill = jsonSaveFile.gameDesignSkill;
        playerStats.levelDesignSkill = jsonSaveFile.levelDesignSkill;
        playerStats.markettingSkill = jsonSaveFile.markettingSkill;

        MadedGames.gameTypes= jsonSaveFile.gameTypes;


        MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
        moneyManager.ChangeMoney(jsonSaveFile.money);

        OwnedItems ownedItems = FindObjectOfType<OwnedItems>();
        ownedItems.ownedItem = jsonSaveFile.ownedItems;
    }

        private void OnApplicationPause(bool pauseStatus) 
    {
      if(pauseStatus)
      {
       Save();  
      }

    }

    private void OnApplicationQuit() {
      Save();
    }

}
