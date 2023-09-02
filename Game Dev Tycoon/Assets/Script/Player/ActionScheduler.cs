using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScheduler : MonoBehaviour
{
   ICancel currentCancel;

   public void StartAction(ICancel a)
   {
      if(currentCancel !=null)
      {
        if(currentCancel != a)
        currentCancel.Cancel();
      }
        currentCancel = a;
   }

   public void CancelAll()
   {
      if(currentCancel == null) return;
      currentCancel.Cancel();
      currentCancel = null;
   }
}
