using System.Collections;
using System.Collections.Generic;
using alexM;
using UnityEditor;
using UnityEngine;

namespace alexM
{
   [CustomEditor(typeof(TriggerEvent))]
   public class TriggerEventEditor : Editor
   {
      public override void OnInspectorGUI()
      {
         base.OnInspectorGUI();

         if (GUILayout.Button("Activate"))
         {
            ((TriggerEvent)target).ActivateDoor();
         }
         
         if (GUILayout.Button("Deactivate"))
         {
            ((TriggerEvent)target).DeactivateDoor();
         }
      }
   }

}