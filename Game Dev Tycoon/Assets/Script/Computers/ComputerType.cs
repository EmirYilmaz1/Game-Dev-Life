using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Computer Type", menuName = "Computer Type")]
public class ComputerType : ScriptableObject
{
    public string computerName;
    public Sprite computerSprite;
    public Transform computer;
    public int cost;
}
