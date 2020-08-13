﻿using System;
using UnityEngine;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        private void Awake()
        {
            GameNetworkManager.AddSpawnPoint(transform);
        }

        private void OnDestroy()
        {
			GameNetworkManager.RemoveSpawnPoint(transform);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 1f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2f);
        }
    }
}
