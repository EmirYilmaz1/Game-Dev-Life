using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Bed : MonoBehaviour,IInteractable
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] float energyGive = 100;
    [SerializeField] GameObject canvas;
    
    Energy energy;
    public void Interact()
    {
         energy = FindObjectOfType<Energy>();
        StartCoroutine(Sleep());
    }

    IEnumerator Sleep()
    {
        playableDirector.Play();
        FindObjectOfType<PlayerHandler>().enabled = false;
        yield return new WaitForSecondsRealtime((float)playableDirector.duration-0.2f);
        canvas.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        energy.IncreaseEnergy(energyGive);
         canvas.SetActive(false);
        FindObjectOfType<PlayerHandler>().enabled = true;
    }

}
