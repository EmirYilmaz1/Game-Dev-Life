using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBed : MonoBehaviour
{
   [SerializeField] Transform starterBed;
    BedType bedType;
    Transform currentBed = null;

    private void Awake() 
    {
       Transform bed = Instantiate(starterBed,transform);
       currentBed = bed;
    }

    public void SpawnTheBed(BedType bedType)
    {
        Destroy(currentBed);
        currentBed = Instantiate(bedType.bedPrefab, transform);

    }
}
