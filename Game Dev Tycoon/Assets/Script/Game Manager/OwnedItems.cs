using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedItems : MonoBehaviour
{
    public List<Furniture> ownedItem = new List<Furniture>();
    public void AddItem(Furniture furniture)
    {
        ownedItem.Add(furniture);
    }
}
