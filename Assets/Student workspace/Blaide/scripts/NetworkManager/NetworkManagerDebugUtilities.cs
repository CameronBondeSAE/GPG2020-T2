using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using NetworkLobbyPlayer = Student_workspace.Dylan.Scripts.NetworkLobby.NetworkLobbyPlayer;

namespace Student_workspace.Blaide.scripts.NetworkManager
{
    public class NetworkManagerDebugUtilities : MonoBehaviour
    {
        public bool DisplayDebugButtons = true;
        public bool hostOnStart = false;
        public bool bypassLobby = false;
        public bool disableChat = false;
        public GameNetworkManager gameNetworkManager;
        public GameObject networkDebugUi;

        public MainMenuStuff MainMenuStuff;
       // public PlayerInfoInput PlayerInfoInput;
        public GameObject lobbyUI;
        public GameObject chatUI;

        // Start is called before the first frame update
        void Start()
        {
            if (networkDebugUi != null)
            {
                if (DisplayDebugButtons)
                {
                    networkDebugUi.SetActive(true);
                }
                else
                {
                    networkDebugUi.SetActive(false);
                }
            }


            gameNetworkManager = GetComponent<GameNetworkManager>();
            MainMenuStuff = FindObjectOfType<MainMenuStuff>();
            if (MainMenuStuff != null)
            {
                lobbyUI = MainMenuStuff.gameObject;
            }
            NetworkLobbyPlayer.OnInstantiated += HandleBypassLobby;
            HandleHostOnStart();
        }
        void HandleHostOnStart()
        {
            if (hostOnStart)
            {
                MainMenuStuff.HostLobby();
                lobbyUI.SetActive(false);
                
            }
        }
        void HandleBypassLobby(NetworkLobbyPlayer n)
        {
            if (disableChat)
            {
                chatUI.SetActive(false);
            }

            if (bypassLobby)
            {
                n.CmdReadyUp();
                gameNetworkManager.StartGame();
            }
        }

        public void DebugSkipLobbyHostNow()
        {
            hostOnStart = true;
            bypassLobby = true;
            MainMenuStuff.HostLobby();
            lobbyUI.SetActive(false);
        }

        public void DebugHostNowToLobby()
        {
            hostOnStart = true;
            bypassLobby = false;
            MainMenuStuff.HostLobby();
            lobbyUI.SetActive(false);
        }

        public void DebugJoinNow(string address)
        {
            gameNetworkManager.networkAddress = address;
            gameNetworkManager.StartClient();
           
            // TODO Only do this if Joining is successful, Probably subscribe to an event, and check connection.
            lobbyUI.SetActive(false);
        }

    }
}
