using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fade : MonoBehaviour
{
    CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }



    public IEnumerator FadeOut(float time)
    {
        
        while(canvasGroup.alpha<1)
        {
            canvasGroup.alpha += Time.deltaTime/time;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator FadeIn(float time)
    {
        
        while(canvasGroup.alpha>0)
        {
            canvasGroup.alpha -= Time.deltaTime/time;
            yield return new WaitForEndOfFrame();
        }
    }
}
