using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRug : MonoBehaviour

{
   [SerializeField] Material newRug;
    Material lastMaterial;

    public void Start()
    {
        NewRug(newRug);
    }
    public void NewRug(Material a)
    {
        GetComponent<Renderer>().material = a;
    }

}
