using UnityEngine;
using Mirror;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    /// <summary>
    /// used for in game player stuff
    /// </summary>
    public class NetworkGamePlayer : NetworkBehaviour
    {
        [SyncVar] public string displayName = "Loading...";
        [SyncVar] public Color playerColor;
                
        public static event Action<NetworkGamePlayer> OnInstantiated;
        private GameNetworkManager room;

        private GameNetworkManager Room
        {
            get
            {
                if (room != null)
                {
                    return room;
                }

                return room = NetworkManager.singleton as GameNetworkManager;
            }
        }

        private void Start()
        {
            OnInstantiated?.Invoke(this);
        }

        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject);

            Room.GamePlayers.Add(this);
			
			Debug.Log("Connection = "+NetworkClient.connection.identity.netId);
			Debug.Log("Player GO = "+netIdentity.netId);
		}

        public override void OnStopClient()
        {
            Room.GamePlayers.Remove(this);
        }

        [Server]
        public void SetPlayerInfo(string displayName,Color playerColor)
        {
            this.displayName = displayName;
            this.playerColor = playerColor;
        }

    }
}