using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class PlayerInfoInput : MonoBehaviour
    {
        [Header("UI")] 
        [SerializeField] private TMP_InputField nameInputField = null;
        [SerializeField] private Button continueButton = null;
        [SerializeField] private ColorPickerRGB colorPickerRgb = null;


        public static string DisplayName { get; private set; }
        public static Color PlayerColor { get; private set; }
        private const string PlayerPrefsNameKey = "PlayerName";
        private const string PlayerPrefsColorKey = "PlayerColor";


        private void Awake()
        {
            SetupPlayerInfo();
            SavePlayerInfo();
        }

        private void Start()
        {

        }

        public void SetupPlayerInfo()
        {

            string defaultName = "Newbie";
            Color defaultColor = Random.ColorHSV(0.2f, 0.8f, 0.3f, 1);
            if (PlayerPrefs.HasKey(PlayerPrefsNameKey))
            {
                if (!string.IsNullOrEmpty(PlayerPrefs.GetString(PlayerPrefsNameKey)))
                {
                    defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);
                }
            }

           // if (PlayerPrefs.HasKey(PlayerPrefsColorKey))
           // {
                ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString(PlayerPrefsColorKey), out defaultColor);
           // }



            nameInputField.text = defaultName;
            
            SetPlayerName(defaultName);
            colorPickerRgb.SetColor(defaultColor);
        }

        public void SetPlayerName(string defaultName)
        {
            continueButton.interactable = !string.IsNullOrEmpty(defaultName);
        }
        

        //triggered by button
        public void SavePlayerInfo()
        {
            DisplayName = nameInputField.text;
            PlayerColor = colorPickerRgb.color;
            
            PlayerPrefs.SetString(PlayerPrefsNameKey,DisplayName);
            PlayerPrefs.SetString(PlayerPrefsColorKey, ColorUtility.ToHtmlStringRGBA(PlayerColor));

        }
    }
}