/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class Player : MonoBehaviour
{
    public InputMaster controls;

    void Awake()
    {
        controls.Player.Shoot.performed += _ => Shoot();
    }

    void Shoot ()
    {
        Debug.Log("I shot the sheriff!");
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

}
*/