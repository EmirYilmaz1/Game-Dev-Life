using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    Stats stats =  new Stats();

    int programing;
    int pixelDesign;
    int modelDesign;
    int marketing;

    void Start()
    {
        programing = stats.programing;
        pixelDesign = stats.pixelDesign;
        modelDesign = stats.modelDesign;
        marketing  = stats.marketing;
    }

}
