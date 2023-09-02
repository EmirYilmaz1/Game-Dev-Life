using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

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

   public void LoadTheScene()
    {
       Fade fade = FindObjectOfType<Fade>();
       StartCoroutine(LoacScene(1,2,fade));
    }
    public IEnumerator LoacScene(float fadeOutTime, float fadeInTime, Fade fade)
    {
        StartCoroutine(fade.FadeOut(fadeOutTime));
        yield return new WaitForSecondsRealtime(fadeOutTime);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }


}
