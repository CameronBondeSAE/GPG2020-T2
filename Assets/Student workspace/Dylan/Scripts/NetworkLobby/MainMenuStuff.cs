using UnityEngine;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class MainMenuStuff : MonoBehaviour
    {
        [SerializeField] private GameNetworkManager gameNetworkManager = null;

        [Header("UI")] [SerializeField] private GameObject landingPagePanel = null;

        public void HostLobby()
        {
            gameNetworkManager.StartHost();

            landingPagePanel.SetActive(false);
        }
    }
}
