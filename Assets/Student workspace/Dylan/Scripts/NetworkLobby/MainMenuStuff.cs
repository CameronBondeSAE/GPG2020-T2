using UnityEngine;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class MainMenuStuff : MonoBehaviour
    {
        [SerializeField] private NetworkManagerLobby networkManager = null;

        [Header("UI")] [SerializeField] private GameObject landingPagePanel = null;

        public void HostLobby()
        {
            networkManager.StartHost();

            landingPagePanel.SetActive(false);
        }
    }
}
