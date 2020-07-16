using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Student_workspace.Blaide.ColorPickers.ColorPicker1
{
    public class ColorPicker : MonoBehaviour
    {
        /// <summary>
        /// This is a colour.
        /// </summary>
        [Tooltip("this is a colour list")]
    
        public List<Color> colours;
        private List<ColorButton> colorButtons;
        public GameObject buttonPrefab;
        public Transform buttonContainer;
        public Image colorDisplay;
        // Start is called before the first frame update
        void Start()
        {
            colorButtons = new List<ColorButton>();
            foreach (Color colour in colours)
            {
                GameObject g = Instantiate(buttonPrefab, buttonContainer);
                Button b = g.GetComponent<Button>();
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = colour;
                colorBlock.highlightedColor = Color.Lerp(colour,Color.white, 0.3f);
                colorBlock.pressedColor =  Color.Lerp(colour,Color.black, 0.3f);;
                colorBlock.selectedColor = colour;
                colorBlock.colorMultiplier = 1;
                b.colors = colorBlock;
                ColorButton colorButton = g.GetComponent<ColorButton>();
                colorButton.OnClick += UpdateColour;
                colorButtons.Add(colorButton);
            
            }
        }

        private void UpdateColour(Color c)
        {
            colorDisplay.color = c;
        }

        // Update is called once per frame

        private void OnDisable()
        {
            foreach (ColorButton colorButton in colorButtons)
            {
                colorButton.OnClick -= UpdateColour;
            }
        }
    }
}
