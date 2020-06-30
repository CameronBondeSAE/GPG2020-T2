using UnityEngine;
using UnityEngine.InputSystem;

namespace Student_workspace.Dylan.Scripts.ActionMapTest
{
    public class TestActionMap : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //remember to enable action map otherwise nothing will work    
            YesInputActionMap actionMap = new YesInputActionMap();
            actionMap.Enable();
            actionMap.AnActionMap.DoAction.performed += DoThing;
        }

        private void DoThing(InputAction.CallbackContext obj)
        {
            Debug.Log("Action Was Done");
        }
    }
}
