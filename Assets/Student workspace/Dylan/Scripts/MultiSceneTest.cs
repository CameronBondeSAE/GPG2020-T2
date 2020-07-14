using System;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Student_workspace.Dylan.Scripts
{
    public class MultiSceneTest : MonoBehaviour
    {
        [Scene] public string MainScene = string.Empty;
        [Scene] public string LobbyScene = string.Empty;

        public void Awake()
        {
            if (!String.IsNullOrEmpty(MainScene) || !String.IsNullOrEmpty(LobbyScene))
            {
                SceneManager.LoadScene(MainScene, LoadSceneMode.Additive);
                SceneManager.LoadScene(LobbyScene);
            }
        }
    }
}