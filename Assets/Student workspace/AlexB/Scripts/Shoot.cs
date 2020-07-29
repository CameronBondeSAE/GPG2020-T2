using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.GlobalIllumination;

namespace AJ
{
    public class Shoot : MonoBehaviour
    {
        private void Update()
        {
            if (InputSystem.GetDevice<Mouse>().leftButton.IsPressed())
            {
                Debug.Log("Shoot");
            }
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Add HP"))
            {
                ((HealthComponent)target).AddHp(10);
            }
        }
    }
}
