using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    /// <summary>
    /// controls joing the lobby, also holds the events that are triggered on player connection and disconnection
    /// </summary>
    public class JoinLobbyMenu : MonoBehaviour
    {
        [SerializeField] private GameNetworkManager gameNetworkManager = null;

        [Header("UI")] 
        [SerializeField] private GameObject landingPagePanel = null;
        [SerializeField] private TMP_InputField ipAddressInputField = null;
        [SerializeField] private Button joinButton = null;

        private void OnEnable()
        {
            GameNetworkManager.OnClientConnected += HandleClientConnected;
            GameNetworkManager.OnClientDisconnected += HandleClientDisconnected;
        }

        private void OnDisable()
        {
            GameNetworkManager.OnClientConnected -= HandleClientConnected;
            GameNetworkManager.OnClientDisconnected -= HandleClientDisconnected;
        }

        public void JoinLobby()
        {
            string ipAddress = ipAddressInputField.text;

            gameNetworkManager.networkAddress = ipAddress;
            gameNetworkManager.StartClient();

            joinButton.interactable = false;
        }
        
        private void HandleClientConnected()
        {
            joinButton.interactable = true;

            gameObject.SetActive(false);
            landingPagePanel.SetActive(false);
        }

        private void HandleClientDisconnected()
        {
            joinButton.interactable = true;
        }

    }
}