using UnityEngine;
using Mirror;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class NetworkGamePlayer : NetworkBehaviour
    {
        //if you wish to change the max amount of players change the array number in the two text fields below

        [SyncVar] private string displayName = "Loading...";

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
        public void SetDisplayName(string displayName)
        {
            this.displayName = displayName;
        }

    }
}