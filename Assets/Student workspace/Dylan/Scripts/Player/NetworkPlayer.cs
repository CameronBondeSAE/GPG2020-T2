using Mirror;

namespace Student_workspace.Dylan.Scripts.Player
{
    public class NetworkPlayer : NetworkBehaviour
    {
        [SyncVar]
        public string playerName;
    }
}
