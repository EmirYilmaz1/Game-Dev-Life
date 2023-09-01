using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("a");
        GetComponentInChildren<Light>().enabled = !GetComponentInChildren<Light>().enabled;
    }
}
