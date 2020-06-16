using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemSimpleExample : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().spaceKey.isPressed)
        {
            Debug.Log("Test polling input system");
        }
    }
}
