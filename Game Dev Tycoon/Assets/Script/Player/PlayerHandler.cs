using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHandler : MonoBehaviour
{
    static bool didSpawn;
    Ray ray;
    RaycastHit raycastHit;
    PlayerMovementHandler playerMovementHandler;
    InteractHandler interactHandler;

    void Start()
    {
        playerMovementHandler = GetComponent<PlayerMovementHandler>();
        interactHandler = GetComponent<InteractHandler>();
    }

    void Update()
    {
        if (ClickedOnUi())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (isMouseOverUI()) return;
            if (InteractTheObjects()) return;
            if (MoveToPoint()) return;
        }
    }

    private bool isMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject(); // This will detect if the player is touching the UI
    }

    private bool InteractTheObjects()
    {
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);
        foreach (RaycastHit raycastHit in raycastHits)
        {
            IInteractable interactable = raycastHit.collider.GetComponent<IInteractable>();

            if (interactable == null) continue;
            Transform targetPos = raycastHit.collider.transform;

            interactHandler.StartInteractAction(targetPos, interactable);
            return true;
        }
        return false;
    }

    private bool MoveToPoint()
    {
        if (Physics.Raycast(ray, out raycastHit))
        {
            playerMovementHandler.MoveAction(raycastHit.point);
            return true;
        }
        return false;
    }

    private bool ClickedOnUi()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (var item in results)
        {
            if (item.gameObject.CompareTag("UI"))
            {
                return true;
            }
        }
        return false;
    }
}