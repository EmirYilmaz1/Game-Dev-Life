using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComputer : MonoBehaviour
{
    [SerializeField] Transform computer;

    Transform recentComputer;
    Transform lastComputer; 
    void Start()
    {
        if(lastComputer!=null)
        {

        }
        else
        {
         recentComputer = Instantiate(computer, transform);
        }
    }

    public void SpawnTheRecentComputer(Transform computer)
    {
        Destroy(recentComputer.gameObject);
        recentComputer =Instantiate(computer, transform);
    }
}
