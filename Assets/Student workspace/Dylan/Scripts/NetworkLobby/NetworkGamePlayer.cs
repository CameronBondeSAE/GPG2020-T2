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


        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject);

            Room.GamePlayers.Add(this);
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