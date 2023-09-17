using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GetComponentInChildren<Light>().enabled = !GetComponentInChildren<Light>().enabled;
    }
}
