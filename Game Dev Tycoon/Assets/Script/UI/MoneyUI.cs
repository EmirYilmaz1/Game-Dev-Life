using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{   
  TextMeshProUGUI moneyUI;
  MoneyManager moneyManager;

  private void Awake() 
  {
    moneyUI = GetComponent<TextMeshProUGUI>();
    moneyManager = FindObjectOfType<MoneyManager>();
    moneyUI.text =  moneyManager.GetCurrentMoney().ToString();

    moneyManager.OnMoneyChange += () => {moneyUI.text =  moneyManager.GetCurrentMoney().ToString();};
  }

}
