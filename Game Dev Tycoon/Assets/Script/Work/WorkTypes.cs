using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Work Type", menuName = "Work Type")]
public class WorkTypes : ScriptableObject
{
    public Sprite workImage;
    public string workName;
    public int moneyGive;
    public int EnergyAmount;
}
