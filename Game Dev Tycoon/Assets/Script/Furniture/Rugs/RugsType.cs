using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rugs Type", menuName = "Rug Type")]
public class RugsType : ScriptableObject
{
    public Sprite rugImage;
    public Material rugMaterial;
    public string rugName;
    public int cost;
}
