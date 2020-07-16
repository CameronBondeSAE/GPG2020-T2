using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

public class BChatNetworkHandler : NetworkBehaviour
{
    private GameNetworkManager gameNetworkManager;
    [TextArea][SyncVar (hook = nameof(ChatHappened))]
        public string chatContent;
    
        public static event Action<string,string> OnMessage;
        public void ChatHappened(string oldValue, string newValue)
        {
            //Debug.Log( newValue.Remove(0,oldValue.Length));
        }
        
        [Command]
        public void CmdSendMessage(string message, string source)
        {
            if (chatContent != "")
            {
                chatContent += "\n";
            }
            chatContent +=  source + ":" + message;
            
            if (message.Trim() != "")
                RpcReceive(message,source);
        }
        
        [ClientRpc]
        public void RpcReceive(string message,string source)
        {
            OnMessage?.Invoke(message,source);
        }

}
