using System;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    /// <summary>
    /// this has no relation to the in-game player this is merely for the lobbies use
    /// </summary>
    public class NetworkLobbyPlayer : NetworkBehaviour
    {
        
        //if you wish to change the max amount of players change the array number in the two text fields below
        [Header("UI")] [SerializeField] private GameObject lobbyUI = null;
        [SerializeField] private TMP_Text[] playerNameTexts;
        [SerializeField] private TMP_Text[] playerReadyTexts;
        [SerializeField] private Button startGameButton = null;

        [SyncVar(hook = nameof(HandleDisplayNameChanged))]
        public string DisplayName = "Loading...";
        [SyncVar(hook = nameof(HandlePlayerColorChanged))]
        public Color PlayerColor;
        [SyncVar(hook = nameof(HandleReadyStatusChanged))]
        public bool IsReady = false;

        private bool isLeader;

        public bool IsLeader
        {
            set
            {
                isLeader = value;
                startGameButton.gameObject.SetActive(value);
            }
        }

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

        public override void OnStartAuthority()
        {
            CmdSetDisplayName(PlayerInfoInput.DisplayName);
            CmdSetPlayerColor(PlayerInfoInput.PlayerColor);

            lobbyUI.SetActive(true);
        }

        public override void OnStartClient()
        {
            Room.RoomPlayers.Add(this);

            UpdateDisplay();
            
        }

        public override void OnStopClient()
        {
            Room.RoomPlayers.Remove(this);

            UpdateDisplay();
        }

        public void HandleReadyStatusChanged(bool oldValue, bool newValue)
        {
            UpdateDisplay();
        }

        public void HandleDisplayNameChanged(string oldValue, string newValue)
        {
            UpdateDisplay();
        }
        
        public void HandlePlayerColorChanged(Color oldValue, Color newValue)
        {
            UpdateDisplay();
        }
        

        private void UpdateDisplay()
        {
            //if we arent the local player go update who is the local player
            if (!hasAuthority)
            {
                foreach (var player in Room.RoomPlayers)
                {
                    if (player.hasAuthority)
                    {
                        player.UpdateDisplay();
                        break;
                    }
                }

                return;
            }

            for (int i = 0; i < playerNameTexts.Length; i++)
            {
                playerNameTexts[i].text = "Waiting For Player...";
                playerReadyTexts[i].text = String.Empty;
            }

            for (int i = 0; i < Room.RoomPlayers.Count; i++)
            {
                playerNameTexts[i].text = Room.RoomPlayers[i].DisplayName;
                playerReadyTexts[i].text = Room.RoomPlayers[i].IsReady
                    ? "<color=green>Ready</color>"
                    : "<color=red>Not Ready</color>";
            }
        }

        public void HandleReadyToStart(bool readyToStart)
        {
            if (!isLeader)
            {
                return;
            }

            startGameButton.interactable = readyToStart;
        }

        [Command]
        private void CmdSetDisplayName(string displayName)
        {
            DisplayName = displayName;
        }

        [Command]
        private void CmdSetPlayerColor(Color playerColor)
        {
            PlayerColor = playerColor;
        }
 
        [Command]
        public void CmdReadyUp()
        {
            IsReady = !IsReady;
            
            Room.NotifyPlayersOfReadyState();
        }

        [Command]
        public void CmdStartGame()
        {
            if (Room.RoomPlayers[0].connectionToClient != connectionToClient)
            {
                return;
            }
            
            Room.StartGame();
        }
    }
}
