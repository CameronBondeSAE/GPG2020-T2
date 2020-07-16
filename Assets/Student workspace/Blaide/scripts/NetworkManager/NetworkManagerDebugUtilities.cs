using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using NetworkLobbyPlayer = Student_workspace.Dylan.Scripts.NetworkLobby.NetworkLobbyPlayer;

namespace Student_workspace.Blaide.scripts.NetworkManager
{
    public class NetworkManagerDebugUtilities : MonoBehaviour
    {
        public bool hostOnStart = false;
        public bool bypassLobby = false;
        public GameNetworkManager gameNetworkManager;

        public MainMenuStuff MainMenuStuff;
       // public PlayerInfoInput PlayerInfoInput;
        public GameObject lobbyUI;

        // Start is called before the first frame update
        void Start()
        {
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
            if (bypassLobby)
            {
                n.CmdReadyUp();
                gameNetworkManager.StartGame();
            }
        }


    }
}
