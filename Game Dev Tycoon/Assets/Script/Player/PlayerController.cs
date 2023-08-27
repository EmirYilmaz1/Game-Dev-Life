using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Ray ray;
    RaycastHit raycastHit;
    Mover mover;
    InterractComputer interractComputer;
    ActionScheduler actionScheduler;
    void Start()
    {
       mover = GetComponent<Mover>();
       interractComputer = GetComponent<InterractComputer>();
       actionScheduler = GetComponent<ActionScheduler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InterractWithComputer()) return;
        InterractWithMovement();
    }

    bool InterractWithComputer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHit = Physics.RaycastAll(ray);
            foreach(RaycastHit raycastHits in raycastHit)
            {
                Computer computer = raycastHits.collider.GetComponent<Computer>();
                if(computer == null) continue;
                interractComputer.A(computer);
                return true;
            }
            return false;
        }
        return false;
    }

    bool InterractWithMovement()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out raycastHit))
            {
            mover.StartActionMove(raycastHit.point);
            return true;
            }
        }

        return false;
    }
}
