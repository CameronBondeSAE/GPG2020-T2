using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.InputSystem;

public class ActiveButton : MonoBehaviour
{
    public GameObject Cube;
    Animator animator;

    void Start()
    {
        animator = Cube.GetComponent<Animator>();
    }

    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().spaceKey.IsPressed())
        {
            Cube.SetActive(false);
            animator.enabled = false;
        }
        else
        {
            Cube.SetActive(true);
            animator.enabled = true;
        }
    }




}
