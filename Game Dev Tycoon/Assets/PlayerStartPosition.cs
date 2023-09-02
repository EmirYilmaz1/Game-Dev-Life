using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = gameObject.transform.position;
    }

}
