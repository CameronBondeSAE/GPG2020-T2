using System;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using NetworkLobbyPlayer = Student_workspace.Dylan.Scripts.NetworkLobby.NetworkLobbyPlayer;

namespace Student_workspace.Blaide.scripts
{
    public class BChatUI : MonoBehaviour
    {
        
        public TextMeshProUGUI textMesh;
        public RectTransform textContainer;
        public ScrollRect scrollRect;
        [TextArea]
        public string chatContent;
        public TMP_InputField inputField;

        public GameNetworkManager gameNetworkManager;
        public BChatNetworkHandler bChatNetworkHandler;
        [HideInInspector]public Color localPlayerColour;
        [HideInInspector]public string localPlayerName;

        public void SetPlayerName( string p)
        {
            localPlayerName = p;
        }

        public void SetPlayerColor( Color c)
        {
            localPlayerColour = c;
        }

        // Start is called before the first frame update
        private void OnEnable()
        {
            inputField.onSubmit.AddListener(OnMessageSubmit);
            UpdateText();
            BChatNetworkHandler.OnMessage += AddMessage;
        }

        private void OnDisable()
        {
            inputField.onSubmit.RemoveListener(OnMessageSubmit);
        }
        public void OnMessageSubmit(string message)
        {
            bChatNetworkHandler = NetworkClient.connection.identity.GetComponent<BChatNetworkHandler>();

            if (bChatNetworkHandler.GetComponent<NetworkLobbyPlayer>() != null)
            {
                localPlayerColour = bChatNetworkHandler.GetComponent<NetworkLobbyPlayer>().PlayerColor;
                localPlayerName = bChatNetworkHandler.GetComponent<NetworkLobbyPlayer>().DisplayName;
            }
            else if (bChatNetworkHandler.GetComponent<NetworkGamePlayer>() != null)
            {
                localPlayerColour = bChatNetworkHandler.GetComponent<NetworkGamePlayer>().playerColor;
                localPlayerName = bChatNetworkHandler.GetComponent<NetworkGamePlayer>().displayName;
            }



            bChatNetworkHandler.CmdSendMessage(message,"<color=#" + ColorUtility.ToHtmlStringRGB( localPlayerColour) +">"+ localPlayerName + "</color>");
            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
        }

        public void AddMessage(string message, string source)
        {
            if (chatContent != "")
            {
                chatContent += "\n";
            }
            
            //bChatNetworkHandler.CmdSendMessage(message,source);

            chatContent +=  source + ":" + message;
            UpdateText();
        }

        public void UpdateText()
        {
            textMesh.text = chatContent;

            Vector2 chatwindowSize = textMesh.GetPreferredValues(textMesh.rectTransform.rect.width, 0);
            textMesh.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,chatwindowSize.y);
            textContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,chatwindowSize.y + textMesh.fontSize);
            textMesh.rectTransform.anchoredPosition = Vector2.zero;
           // ScrollView.scrollOffset = 
           scrollRect.verticalNormalizedPosition = 0;
        }

    }
}
