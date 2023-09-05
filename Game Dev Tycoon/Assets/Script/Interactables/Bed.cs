using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour,IInteractable
{
    [SerializeField] float energyGive;
    public void Interact()
    {
       Energy energy = FindObjectOfType<Energy>();
       energy.IncreaseEnergy(energyGive);
    }

}
