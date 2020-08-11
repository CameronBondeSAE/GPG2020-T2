using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreeCameraNew : MonoBehaviour
{
    /// <summary>
    /// Rotation speed when using the mouse.
    /// </summary>
    public float m_LookSpeedMouse = 10.0f;

    /// <summary>
    /// Movement speed.
    /// </summary>
    public float m_MoveSpeed = 10.0f;
    
    private bool Aiming = false;

    GameControls gameControls;
    Vector2 direction;
    
    private void OnEnable()
    {
        gameControls = new GameControls();

        gameControls.Enable();
        gameControls.InGame.Enable();
        gameControls.InGame.Move.performed += MoveOnperformed;
        gameControls.InGame.Move.canceled += MoveOnperformed;
        gameControls.InGame.Look.performed += MousePositionOnperformed;
        gameControls.InGame.Fire.performed += FireOnperformed;
        gameControls.InGame.Fire.canceled += FireOncanceled;
    }

    private void OnDisable()
    {
        gameControls.Disable();
        gameControls.InGame.Disable();
        gameControls.InGame.Move.performed -= MoveOnperformed;
        gameControls.InGame.Move.canceled -= MoveOnperformed;
        gameControls.InGame.Look.performed -= MousePositionOnperformed;
        gameControls.InGame.Fire.performed -= FireOnperformed;
        gameControls.InGame.Fire.canceled -= FireOncanceled;
    }

    private void FireOnperformed(InputAction.CallbackContext obj)
    {
        Aiming = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FireOncanceled(InputAction.CallbackContext obj)
    {
        Aiming = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void MousePositionOnperformed(InputAction.CallbackContext obj)
    {
        Vector2 inputRotateVector;
        inputRotateVector = obj.ReadValue<Vector2>() * m_LookSpeedMouse;

        if (Aiming)
        {
            float rotationX = transform.localEulerAngles.x;
            float newRotationY = transform.localEulerAngles.y + inputRotateVector.x;

            // Weird clamping code due to weird Euler angle mapping...
            float newRotationX = (rotationX - inputRotateVector.y);
            if (rotationX <= 90.0f && newRotationX >= 0.0f)
                newRotationX = Mathf.Clamp(newRotationX, 0.0f, 90.0f);
            if (rotationX >= 270.0f)
                newRotationX = Mathf.Clamp(newRotationX, 270.0f, 360.0f);

            transform.localRotation = Quaternion.Euler(newRotationX, newRotationY, transform.localEulerAngles.z);
        }
    }
    private void MoveOnperformed(InputAction.CallbackContext obj)
    {
        
        direction = obj.ReadValue<Vector2>();
    
        
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        float moveSpeed = Time.deltaTime * m_MoveSpeed;
        transform.position += transform.forward * moveSpeed * direction.y;
        transform.position += transform.right * moveSpeed * direction.x;
        // transform.position += Vector3.up * moveSpeed * inputYAxis;
    }
}