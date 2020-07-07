using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Student_workspace.Dylan.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class GameNetworkManager : NetworkManager
    {
        [SerializeField] private int minPlayer = 2;
        
        [Scene] [SerializeField] private string menuScene = string.Empty;
        [Scene] [SerializeField] private string gameScene = string.Empty;

        
        [Header("Room")] [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

        [Header("Game")] [SerializeField] private NetworkGamePlayer gamePlayerPrefab = null;

        
        public static event Action OnClientConnected;
        public static event Action OnClientDisconnected;

        public List<NetworkRoomPlayerLobby> RoomPlayers { get; } = new  List<NetworkRoomPlayerLobby>();
        
        public List<NetworkGamePlayer> GamePlayers { get; } = new  List<NetworkGamePlayer>();

        public override void Awake()
        {
            
            base.Awake();
        }


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
            base.OnClientConnect(conn);
            OnClientConnected?.Invoke();
        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
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
                
                NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);

                roomPlayerInstance.IsLeader = isLeader;
                
                NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
            }
        }
        
        
        public override void OnServerDisconnect(NetworkConnection conn)
        {
            if (conn.identity != null)
            {
                var player = conn.identity.GetComponent<NetworkRoomPlayerLobby>();

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
            if (SceneManager.GetActiveScene().name == menuScene)
            {
                if (!IsReadyToStart())
                {
                    return;
                }
                ServerChangeScene("GameSceneTst");
            }
        }

        public override void ServerChangeScene(string newSceneName)
        {
            if (SceneManager.GetActiveScene().name == menuScene && newSceneName.StartsWith("GameSceneTst"))
            {
                for (int i = RoomPlayers.Count - 1; i >= 0; i--)
                {
                    var conn = RoomPlayers[i].connectionToClient;
                    var gameplayerInstance = Instantiate(gamePlayerPrefab);
                    gameplayerInstance.SetDisplayName(RoomPlayers[i].DisplayName);

                    NetworkServer.Destroy(conn.identity.gameObject);

                    NetworkServer.ReplacePlayerForConnection(conn, gameplayerInstance.gameObject);
                }
            }
            
            base.ServerChangeScene(newSceneName);
        }
    }
}