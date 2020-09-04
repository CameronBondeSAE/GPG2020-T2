using UnityEngine;
using Mirror;
using TMPro;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
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

        private GameControls _gameControls;
        public static event Action<NetworkGamePlayer> OnInstantiated;
        private GameNetworkManager room;

        public IPossessable possessable;

        public GameObject pauseMenu;

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
            
            //FindPosessable();
            EnableControls();
        }

         public void EnableControls()
        {
            if (netIdentity.isLocalPlayer)
            {
                _gameControls.Enable();
            }
        }

         public void DisableControls()
         {
             if (netIdentity.isLocalPlayer)
             {
                 _gameControls.Disable();
             }
         }

         void FindPosessable()
        {
            
            
            
            // TODO Probably pass the Possessable to this script rather than searching for it on start.... Bit of  HACK.
            var ss = FindObjectsOfType<MonoBehaviour>().OfType<IPossessable>();
            foreach (IPossessable s in ss)
            {
                if (((IOwnable) s).Owner = netIdentity)
                {
                    possessable = s;
                }
            }
        }

        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject);

            Room.GamePlayers.Add(this);

            // Debug.Log("Connection = " + NetworkClient.connection.identity.netId);
            // Debug.Log("Player GO = " + netIdentity.netId);
        }

		
		// LOCAL Client side object is fully usable at this stage
		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();
			
			
		}

        
        public override void OnStopClient()
        {
            Room.GamePlayers.Remove(this);
        }

        [Server]
        public void SetPlayerInfo(string displayName, Color playerColor)
        {
            this.displayName = displayName;
            this.playerColor = playerColor;
        }

        private void OnEnable()
        {
            //if (isLocalPlayer)
            //{
                _gameControls = new GameControls();
                EnableControls();
                _gameControls.InGame.Move.performed += MoveOnInputChange;
                _gameControls.InGame.Move.canceled += MoveOnInputChange;
                _gameControls.InGame.MousePosition.performed += LookOnInputChange;
                _gameControls.InGame.MousePosition.canceled += LookOnInputChange;
                _gameControls.InGame.Fire.performed += FireOnInputChange;
                _gameControls.InGame.Fire.canceled += FireOnInputChange;
                _gameControls.InGame.Jump.performed += JumpOnInputChange;
                _gameControls.InGame.Jump.canceled += JumpOnInputChange;
                _gameControls.InGame.OpenPauseMenu.performed += OpenPauseMenu;
                //}

        }

        
        private void OpenPauseMenu(InputAction.CallbackContext obj)
        {
            pauseMenu.SetActive(true);
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
        }

        private void JumpOnInputChange(InputAction.CallbackContext obj)
        {
            if(possessable != null)
                possessable.Jump(obj);
        }

        private void OnDisable()
        {


                _gameControls.InGame.Move.performed -= MoveOnInputChange;
                _gameControls.InGame.Move.canceled -= MoveOnInputChange;
                _gameControls.InGame.MousePosition.performed -= LookOnInputChange;
                _gameControls.InGame.MousePosition.canceled -= LookOnInputChange;
                _gameControls.InGame.Fire.performed -= FireOnInputChange;
                _gameControls.InGame.Fire.canceled -= FireOnInputChange;
                _gameControls.InGame.Jump.performed -= JumpOnInputChange;
                _gameControls.InGame.Jump.canceled -= JumpOnInputChange;


        }

        private void OnDestroy()
        {
            _gameControls.InGame.Move.performed -= MoveOnInputChange;
            _gameControls.InGame.Move.canceled -= MoveOnInputChange;
            _gameControls.InGame.MousePosition.performed -= LookOnInputChange;
            _gameControls.InGame.MousePosition.canceled -= LookOnInputChange;
            _gameControls.InGame.Fire.performed -= FireOnInputChange;
            _gameControls.InGame.Fire.canceled -= FireOnInputChange;
            _gameControls.InGame.Jump.performed -= JumpOnInputChange;
            _gameControls.InGame.Jump.canceled -= JumpOnInputChange;
        }


        public void RespawnPossessable()
        {
            Respawnable res;
            Component comp;
            if (possessable != null)
            {

                if (((MonoBehaviour) possessable).TryGetComponent(typeof(Respawnable), out comp))
                {
                    res = (Respawnable) comp;
                    res.Respawn();

                }
            }
        }


        private void FireOnInputChange(InputAction.CallbackContext obj)
        {
            if (possessable != null)
            {
                possessable.Fire(obj);
            }
            else
            {
                Debug.Log("Possesable = null");
                FindPosessable();
            }
        }

        private void LookOnInputChange(InputAction.CallbackContext obj)
        {
            if (possessable != null)
            {
                possessable.Aiming(obj.ReadValue<Vector2>(),obj);
            }
            else
            {
                Debug.Log("Possesable = null");
                FindPosessable();
            }
        }

        private void MoveOnInputChange(InputAction.CallbackContext obj)
        {
            if (possessable != null)
            {
                possessable.Movement(obj.ReadValue<Vector2>(),obj);
            }
            else
            {
                Debug.Log("Possesable = null");
                FindPosessable();
            }
        }
        
        
        
        
        
    }
}
