using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEvents : MonoBehaviour
{
    public UnityEvent startEvent;
    public UnityEvent awakeEvent;
    public UnityEvent destroyEvent;
    public UnityEvent enableEvent;
    public UnityEvent disableEvent;

    private void Awake()
    {
        awakeEvent.Invoke();
    }

    void Start()
    {
        startEvent.Invoke();
    }

    private void OnDestroy()
    {
        destroyEvent.Invoke();
    }

    private void OnEnable()
    {
        enableEvent.Invoke();
    }

    private void OnDisable()
    {
        disableEvent.Invoke();
    }
}
