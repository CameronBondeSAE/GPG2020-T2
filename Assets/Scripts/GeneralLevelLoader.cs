﻿using System;
using alexM;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

public class GeneralLevelLoader : NetworkBehaviour
{
    public static event Action<string,bool> LoadLevelEvent;

    [Scene]
    public string levelToLoad;

    public bool LoadNextLevel = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isServer)
        {
            if (other != null)
            {
                if (other.transform.root.GetComponent<PlayerControllerTopDown>())
                {
                    LoadLevel();
                }
            }
        }
    }

    [Server]
    public void LoadLevel()
    {
        LoadLevelEvent?.Invoke(levelToLoad,LoadNextLevel);
    }
}