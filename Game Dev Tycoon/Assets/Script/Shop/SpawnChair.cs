using UnityEngine;

public class SpawnChair : MonoBehaviour 
{
    [SerializeField] Transform startChair;
    Transform currentChair;
    private void Awake() 
    {
        currentChair = Instantiate(startChair,transform);
    }

    public void SpawnTheChair(ChairType chairType)
    {
        Destroy(currentChair.gameObject);
        currentChair = Instantiate(chairType.chairPrefab,transform);
    }
}