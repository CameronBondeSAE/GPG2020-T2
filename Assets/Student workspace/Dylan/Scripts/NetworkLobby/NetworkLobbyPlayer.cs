using System;
using System.Collections.Generic;
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
        [Header("UI")]
        [SerializeField]
        private GameObject lobbyUI = null;
        
        [SerializeField]
        private List<PlayerLobbyDisplay> playerLobbyDisplays = new List<PlayerLobbyDisplay>();

        [SerializeField]
        private Button startGameButton = null;
        
        public static event Action<NetworkLobbyPlayer> OnInstantiated;

        [SyncVar(hook = nameof(HandleDisplayNameChanged))]
        public string DisplayName = "Loading...";

        [SyncVar(hook = nameof(HandlePlayerColorChanged))]
        public Color PlayerColor;

        [SyncVar(hook = nameof(HandleReadyStatusChanged))]
        public bool IsReady = false;

        private bool isLeader;

        public GameObject playerLobbyDisplayPrefab;
        public Transform playerLobbyDisplayPanel;

        public bool IsLeader
        {
            get => isLeader;
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

        private void OnEnable()
        {
            GameNetworkManager.OnGameStart += hideUI;
        }

        public void hideUI()
        {
            if (lobbyUI != null) lobbyUI.SetActive(false);
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
            OnInstantiated?.Invoke(this);
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

            /*for (int i = 0; i < playerNameTexts.Length; i++)
            {
                playerNameTexts[i].text = "Waiting For Player...";
                playerReadyTexts[i].text = String.Empty;
            }*/

            if (Room.RoomPlayers.Count > playerLobbyDisplays.Count)
            {
                playerLobbyDisplays.Add(NewPlayerDisplay());
            }
            else if (Room.RoomPlayers.Count < playerLobbyDisplays.Count)
            {
                PlayerLobbyDisplay p = playerLobbyDisplays[playerLobbyDisplays.Count - 1];
                playerLobbyDisplays.Remove(playerLobbyDisplays[playerLobbyDisplays.Count-1]); 
                Destroy(p.gameObject);
            }

            for (var index = 0; index < Room.RoomPlayers.Count; index++)
            {
                playerLobbyDisplays[index].nameText.text = Room.RoomPlayers[index].DisplayName;
                playerLobbyDisplays[index].readyText.text = Room.RoomPlayers[index].IsReady
                    ? "<color=green>Ready</color>"
                    : "<color=red>Not Ready</color>";
            }

            /*for (int i = 0; i < Room.RoomPlayers.Count; i++)
            {
                playerNameTexts[i].text = Room.RoomPlayers[i].DisplayName;
                playerReadyTexts[i].text = Room.RoomPlayers[i].IsReady
                    ? "<color=green>Ready</color>"
                    : "<color=red>Not Ready</color>";
            }*/
        }

        public PlayerLobbyDisplay NewPlayerDisplay()
        {
            PlayerLobbyDisplay p = Instantiate(playerLobbyDisplayPrefab, playerLobbyDisplayPanel)
                .GetComponent<PlayerLobbyDisplay>();
            return p;
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

        public void DisconnectFromGame()
        {
            if (isLeader)
            {
                room.StopHost();
            }
            else
            {
                room.StopClient();
            }
        }

        [SerializeField]
        private Button restartButton;

        public void RestartLevel()
        {
            if (isLeader)
            {
                room.RestartLevel();
                restartButton.gameObject.SetActive(true);
            }
            else
            {
                restartButton.gameObject.SetActive(false);
                //only restart if you are the leader
            }
        }
    }
}