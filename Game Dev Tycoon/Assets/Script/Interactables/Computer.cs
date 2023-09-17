using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject computerCanvas;
    [SerializeField] private PlayableDirector playableDirector;
    public void Interact()
    {
        StartCoroutine(Sqeunce());
    }

    IEnumerator Sqeunce()
    {
        FindObjectOfType<PlayerHandler>().enabled = false;
        playableDirector.Play();
        yield return new WaitForSecondsRealtime(1.7f);
        computerCanvas.SetActive(true);
         FindObjectOfType<PlayerHandler>().enabled = true;
    }

    
}
