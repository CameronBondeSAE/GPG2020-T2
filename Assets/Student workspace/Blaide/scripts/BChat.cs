using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Student_workspace.Blaide.scripts
{
    public class BChat : MonoBehaviour
    {
        
        public TextMeshProUGUI textMesh;
        public RectTransform textContainer;
        public ScrollRect scrollRect;
        
        [TextArea]
        public string chatContent;
        public TMP_InputField inputField;

        public Color localPlayerColour;
        public string localPlayerName;
        
        // Start is called before the first frame update
        private void OnEnable()
        {
            inputField.onSubmit.AddListener(OnMessageSubmit);
            UpdateText();
        }

        private void OnDisable()
        {
            inputField.onSubmit.RemoveListener(OnMessageSubmit);
        }
        public void OnMessageSubmit(string message)
        {
            AddMessage(message,localPlayerName);
            
            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
        }

        private void AddMessage(string message, string source)
        {
            if (chatContent != "")
            {
                chatContent += "\n";
            }

            chatContent += "<color=#" + ColorUtility.ToHtmlStringRGB( localPlayerColour) +">"+ source + "</color>" + ":" + message;
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
