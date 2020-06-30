using Mirror;
using UnityEngine;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class NetworkRoomPlayerLobby : NetworkBehaviour
    {

        [SyncVar]
        public string playerName;

    }
}
