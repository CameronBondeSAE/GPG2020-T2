using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Student_workspace.Blaide.scripts;
using Student_workspace.Dylan.Scripts.Player;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class GameNetworkManager : NetworkManager
    {
        [SerializeField] private int minPlayer = 2;

        [Scene] [SerializeField] private string menuScene = string.Empty;
        [Scene] [SerializeField] private string gameScene = string.Empty;

        [Header("Room")] [SerializeField] private NetworkLobbyPlayer lobbyPlayerPrefab = null;
        [Header("Game")] [SerializeField] private NetworkGamePlayer gamePlayerPrefab = null;
        
        [Header("BChatUI")] [SerializeField] private BChatUI bChatUI = null;
        

        [SerializeField] private GameObject playerSpawnSystem;


        public static event Action OnClientConnected;
        public static event Action OnClientDisconnected;
        public static event Action<NetworkConnection> OnServerReadied;

        public List<NetworkLobbyPlayer> RoomPlayers { get; } = new List<NetworkLobbyPlayer>();

        public List<NetworkGamePlayer> GamePlayers { get; } = new List<NetworkGamePlayer>();


        /// <summary>
        ///when using prefabs to spawn objects you need to load them in when you start or connect to the server
        /// </summary>
        public override void OnStartServer() =>
            spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();

        /// <summary>
        ///when using prefabs to spawn objects you need to load them in when you start or connect to the server
        /// </summary>
        public override void OnStartClient()
        {
            var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");

            foreach (var prefab in spawnablePrefabs)
            {
                ClientScene.RegisterPrefab(prefab);
            }
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            /*
            bChat = Instantiate(bChatPrefab);
            bChat.netIdentity.AssignClientAuthority(conn);
            bChat.SetPlayerColor(PlayerInfoInput.PlayerColor);
            bChat.SetPlayerName(PlayerInfoInput.DisplayName);
            */

            base.OnClientConnect(conn);
            OnClientConnected?.Invoke();
        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
            /*Destroy(bChat);*/
            base.OnClientDisconnect(conn);
            OnClientDisconnected?.Invoke();
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            if (numPlayers >= maxConnections)
            {
                conn.Disconnect();
                return;
            }

            //this does stop joining in progress will need to change depending on game requirement
            if (SceneManager.GetActiveScene().path != menuScene)
            {
                conn.Disconnect();
                return;
            }
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            if (SceneManager.GetActiveScene().path == menuScene)
            {
                bool isLeader = RoomPlayers.Count == 0;

                NetworkLobbyPlayer lobbyPlayerInstance = Instantiate(lobbyPlayerPrefab);

                lobbyPlayerInstance.IsLeader = isLeader;

                NetworkServer.AddPlayerForConnection(conn, lobbyPlayerInstance.gameObject);
                lobbyPlayerInstance.GetComponent<BChatNetworkHandler>().enabled = true;
                bChatUI.gameObject.SetActive(true);
            }
        }


        public override void OnServerDisconnect(NetworkConnection conn)
        {
            if (conn.identity != null)
            {
                var player = conn.identity.GetComponent<NetworkLobbyPlayer>();

                RoomPlayers.Remove(player);

                NotifyPlayersOfReadyState();
            }

            base.OnServerDisconnect(conn);
        }

        public override void OnStopServer()
        {
            RoomPlayers.Clear();
            base.OnStopServer();
        }


        public void NotifyPlayersOfReadyState()
        {
            foreach (var player in RoomPlayers)
            {
                player.HandleReadyToStart(IsReadyToStart());
            }
        }

        private bool IsReadyToStart()
        {
            if (numPlayers < minPlayer)
            {
                return false;
            }

            foreach (var player in RoomPlayers)
            {
                if (!player.IsReady)
                {
                    return false;
                }
            }


            return true;
        }


        public void StartGame()
        {
            if (SceneManager.GetActiveScene().path == menuScene)
            {
                if (!IsReadyToStart())
                {
                    return;
                }

                ServerChangeScene(gameScene);
            }
        }


        public override void ServerChangeScene(string newSceneName)
        {
            if (SceneManager.GetActiveScene().path == menuScene && newSceneName.StartsWith(gameScene))
            {
                for (int i = RoomPlayers.Count - 1; i >= 0; i--)
                {
                    var conn = RoomPlayers[i].connectionToClient;
                    var gameplayerInstance = Instantiate(gamePlayerPrefab);
                    gameplayerInstance.SetPlayerInfo(RoomPlayers[i].DisplayName,RoomPlayers[i].PlayerColor);

                    NetworkServer.Destroy(conn.identity.gameObject);

                    NetworkServer.ReplacePlayerForConnection(conn, gameplayerInstance.gameObject, true);
                }
            }
            base.ServerChangeScene(newSceneName);
        }

        public override void OnServerChangeScene(string sceneName)
        {
            if (sceneName.StartsWith(gameScene))
            {
                GameObject playerSpawnSystemInstance = Instantiate(playerSpawnSystem);
                NetworkServer.Spawn(playerSpawnSystemInstance);
            }
            // base.OnServerChangeScene(sceneName);
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            base.OnServerReady(conn);

            OnServerReadied?.Invoke(conn);
        }
    }
}