using System;
using System.Collections.Generic;
using System.Linq;
using alexM;
using Mirror;
using UnityEngine;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class PlayerSpawnSystem : NetworkBehaviour
    {
        [SerializeField] private GameObject playerPrefab = null;
        
        private static List<Transform> spawnPoints = new List<Transform>();

        private int nextIndex = 0;

        public static void AddSpawnPoint(Transform transform)
        {
            spawnPoints.Add(transform);

            spawnPoints = spawnPoints.OrderBy(x => x.GetSiblingIndex()).ToList();
        }

        public static void RemoveSpawnPoint(Transform transform)
        {
            spawnPoints.Remove(transform);
        }

        public override void OnStartServer()
        {
            GameNetworkManager.OnServerReadied += SpawnPlayer;
        }

        //[ServerCallback]
        // private void OnDestroy() => GameNetworkManager.OnServerReadied -= SpawnPlayer;
        private void OnDestroy()
         { 
             if(isServer)
                GameNetworkManager.OnServerReadied -= SpawnPlayer;
         }

        [Server]
        public void SpawnPlayer(NetworkConnection conn)
        {
            Transform spawnPoint = spawnPoints.ElementAtOrDefault(nextIndex);

            if (spawnPoint == null)
            {
                Debug.LogError($"Missing spawn point for player {nextIndex}");
                return;
            }

            GameObject playerInstance = Instantiate(playerPrefab, spawnPoints[nextIndex].position,
                spawnPoints[nextIndex].rotation);
            NetworkServer.Spawn(playerInstance,conn);

            if (playerInstance.GetComponent<PlayerControllerTopDown>() != null)
            {
                playerInstance.GetComponent<PlayerControllerTopDown>().Owner = conn.identity;
            }

            nextIndex++;
        }



    }
}
