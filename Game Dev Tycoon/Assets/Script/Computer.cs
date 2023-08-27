using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private GameObject computerBackGround;
    InterractComputer interractComputer;
    void Start()
    {
        interractComputer =FindObjectOfType<InterractComputer>();
        interractComputer.OnOpenComputer += OpenComputer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OpenComputer()
    {
        if(interractComputer.isClicked)
        {
            computerBackGround.SetActive(true);
        }
    }

}
