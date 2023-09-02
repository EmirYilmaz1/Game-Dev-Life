using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int currentMoney = 0;

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public void DecreaseMoney(int amount)
    {
        currentMoney -= amount;
    }

    public void IncreaseMoney(int amount)
    {
        currentMoney += amount;
    }

    public bool CanAfford(int amount)
    {
        if(currentMoney -amount<0)
        {
            return true;
        }
        return false;
    }
}
