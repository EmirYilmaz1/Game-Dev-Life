using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWardrobe : MonoBehaviour
{
   [SerializeField]  Transform starterWardrobe;
    Transform currentWardrobe;
    void Awake()
    {
      currentWardrobe = Instantiate(starterWardrobe, transform);  
    }


    public void Spawner(WardrobeTypes wardrobeTypes)
    {
        Destroy(currentWardrobe.gameObject);
        currentWardrobe = Instantiate(wardrobeTypes.wardrobePrefab,transform);
    }
}
