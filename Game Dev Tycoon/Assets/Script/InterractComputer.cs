using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractComputer : MonoBehaviour, ICancel
{
    public Action OnOpenComputer;

    [SerializeField] float distance = 1f;
    Computer target;
    Mover mover;

    public    bool isClicked;

    private void Awake()
    {
      mover = GetComponent<Mover>();  
    }
    void Update()
    {
       if(target!=null)
       {
            if(distance<Vector3.Distance(transform.position,target.transform.position))
            mover.StartMove(target.transform.position);
            else
            {
                mover.Cancel();
                if(isClicked)
                OnOpenComputer?.Invoke();
            }
            
       } 
    }

    public void A(Computer computerPos)
    {
        isClicked = true;
        GetComponent<ActionScheduler>().StartAction(this);
        target = computerPos;
    }

    public void Cancel()
    {
        isClicked = false;
        target = null;
    }
}
