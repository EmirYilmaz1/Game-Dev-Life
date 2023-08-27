using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScheduler : MonoBehaviour
{
   ICancel lastAction;

   public void StartAction(ICancel action)
    {
        if(lastAction != action)
        {
            if(lastAction!=null)
            lastAction.Cancel();

            lastAction = action;
        }
        
    }
}
