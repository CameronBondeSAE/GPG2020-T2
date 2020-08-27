using System;
using alexM;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

namespace Student_workspace.Dylan.Scripts
{
    public class GeneralLevelLoader : MonoBehaviour
    {
        public static event Action<string> LoadLevelEvent;

        [Scene]
        public string levelToLoad;
        private void OnCollisionEnter(Collision other)
        {
            if (other != null)
            {
                if(other.gameObject.GetComponent<PlayerControllerTopDown>())
                {
                    LoadLevelEvent?.Invoke(levelToLoad);
                }
            }
        }
    }
}
