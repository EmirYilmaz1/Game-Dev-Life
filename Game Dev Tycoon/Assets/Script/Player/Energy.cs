using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
   public Action OnEnergyChange;
   private int energy = 100;

   public int EnergyAmount()
   {
     return energy;
   }

   public void DecreaseEnergy(int amount)
   {
     if(energy-amount>=0)
     energy-=amount;

     Debug.Log(energy);
     OnEnergyChange?.Invoke();
   }

   public void IncreaseEnergy(int amount)
   {
     if(energy+amount<100)
     energy+=amount;
     else 
     energy = 100;
   }
}
