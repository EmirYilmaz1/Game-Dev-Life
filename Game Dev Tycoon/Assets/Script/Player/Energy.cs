using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
   public Action OnEnergyChange;  
   private float energy = 100;

   public float GetEnergyAmount()
   {
        return energy;
   }

   public void DecreaseEnergy(float amount)
   {    
     energy -= amount;
     OnEnergyChange?.Invoke();
   }

   public void IncreaseEnergy(float amount)
   {
        if(energy+amount<=100)
        energy+=amount;
        else 
        energy = 100;

        OnEnergyChange?.Invoke();
   }

   public bool CanAfford(float amount)
   {
     if(energy-amount>=0)
     {
        return true;
     }
     return false;
   }

}
