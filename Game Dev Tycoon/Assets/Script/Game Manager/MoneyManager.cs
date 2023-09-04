using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public Action OnMoneyChange;
    public int currentMoney = 0;

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public void DecreaseMoney(int amount)
    {
        currentMoney -= amount;
        OnMoneyChange?.Invoke();
    }

    public void IncreaseMoney(int amount)
    {
        currentMoney += amount;
        OnMoneyChange?.Invoke();
    }

    public bool CanAfford(int amount)
    {
        if(currentMoney -amount>=0)
        {
            return true;
        }
        return false;
    }
}
