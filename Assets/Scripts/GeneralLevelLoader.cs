using System;
using alexM;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

public class GeneralLevelLoader : MonoBehaviour
{
    public static event Action<string> LoadLevelEvent;

    [Scene]
    public string levelToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if(other.gameObject.GetComponent<PlayerControllerTopDown>())
            {
                LoadLevel();
            }
        }
    }

    public void LoadLevel()
    {
        LoadLevelEvent?.Invoke(levelToLoad);
    }
}