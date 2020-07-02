using Mirror;
using UnityEngine;

namespace Student_workspace.Blaide
{
    public class NetworkManagerTest : NetworkManager
    {
        public void SetHostName(string hostName)
        {
            networkAddress = hostName;
        }

        public override void OnStartServer()
        {
            Debug.Log("server started :"
            + networkAddress);
            
            base.OnStartServer();

        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            Debug.Log(" Connected to server at :" + networkAddress);
            base.OnClientConnect(conn);
        }
        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            if (numPlayers >= maxConnections)
            {
                conn.Disconnect();
                return;
            }

        }
    }
}
