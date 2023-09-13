using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHandler:MonoBehaviour, ICancel
{
    Transform interactTransform;
    PlayerMovementHandler playerMovement;
    IInteractable interactable;
    ActionScheduler actionScheduler;

    private void Awake() 
    {
        actionScheduler = GetComponent<ActionScheduler>();
        playerMovement = GetComponent<PlayerMovementHandler>();
    }

    private void Update() 
    {
        if(interactTransform != null)
        {
            GoToTarget(playerMovement, interactTransform.position, interactable);
        }   
    }

    private void GoToTarget(PlayerMovementHandler playerMovementHandler, Vector3 targetPosition, IInteractable interactable)
    {
        bool isDistance = 2>Vector3.Distance(transform.position, targetPosition);
        
        if(!isDistance)
        playerMovementHandler.Mover(targetPosition);
        else if(isDistance)
        {
            playerMovementHandler.Stop();
            InterractWithIt(interactable);
            Cancel();
        }
    }
    
    private void InterractWithIt(IInteractable interactable)
    {
        interactable.Interact();
    }

   public void StartInteractAction(Transform transform, IInteractable interactable)
    {   
        actionScheduler.StartAction(this);
        interactTransform = transform;
        this.interactable = interactable;
    }

    public void Cancel()
    {
        interactTransform = null;
    }
}
