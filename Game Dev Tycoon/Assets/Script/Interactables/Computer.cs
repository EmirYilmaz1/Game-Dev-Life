using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] Canvas computerCanvas;
    public void Interact()
    {
        computerCanvas.enabled = true;
    }

    
}
