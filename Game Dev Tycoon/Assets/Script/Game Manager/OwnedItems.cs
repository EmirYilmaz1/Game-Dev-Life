using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedItems : MonoBehaviour
{
    [SerializeField] List<ComputerType> ownedComputers = new List<ComputerType>();
    public List<ComputerType> CheckOwnedComputer()
    {
        return ownedComputers;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void AddComputer(ComputerType computerType)
    {
        ownedComputers.Add(computerType);
    }
}
