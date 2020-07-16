using System;
using UnityEngine;
using UnityEngine.UI;

namespace Student_workspace.Blaide
{
    public class ColorButton : MonoBehaviour
    {
        public event Action<Color> OnClick; 
        private Button button;
        void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(Click);
            
        }

        void Click()
        {
            OnClick?.Invoke(button.colors.normalColor);
        }

    }
}
