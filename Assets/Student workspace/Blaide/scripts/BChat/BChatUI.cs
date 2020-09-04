using System;
using System.Text.RegularExpressions;
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
        public NetworkGamePlayer localPlayer;


        public void onInputFieldSelected(string s)
        {
            foreach (NetworkGamePlayer networkGamePlayer in gameNetworkManager.GamePlayers)
            {
                networkGamePlayer.DisableControls();
            }
        }

        public void onInputFieldDeslected(string s)
        {
            foreach (NetworkGamePlayer networkGamePlayer in gameNetworkManager.GamePlayers)
            {
                networkGamePlayer.EnableControls();
            }
        }


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
            
            inputField.onSelect.AddListener(onInputFieldSelected);
            inputField.onDeselect.AddListener(onInputFieldDeslected);
            

        }

        private void Awake()
        {
            GameNetworkManager.OnClientConnected += OnClientConnected;
            GameNetworkManager.OnClientDisconnected += OnClientDisconnected;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            GameNetworkManager.OnClientConnected -= OnClientConnected;
            GameNetworkManager.OnClientDisconnected -= OnClientDisconnected;
        }

        private void OnClientDisconnected()
        {
            gameObject.SetActive(false);
        }

        private void OnClientConnected()
        {
            gameObject.SetActive(true);
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

        public string FilterForNaughtyWords( string input)
        {
            string temp = input;
            foreach (string naughtyWord in GetComponent<CSVReader>().naughtyWords)
            {
                string replacement = "";
                for (int i = 0; i < naughtyWord.Length; i++)
                {
                    replacement += "*";
                }
                
               temp = Regex.Replace(temp, naughtyWord, replacement, RegexOptions.IgnoreCase);
               // temp = temp.Replace(naughtyWord, replacement);
            }

            return temp;
        }

        public void AddMessage(string message, string source)
        {
            string filteredMessage = FilterForNaughtyWords(message);
            
            
            if (chatContent != "")
            {
                chatContent += "\n";
            }
            
            //bChatNetworkHandler.CmdSendMessage(message,source);

            chatContent +=  source + ":" + filteredMessage;
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
