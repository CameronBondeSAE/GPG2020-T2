using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
	public class ColourChanger : MonoBehaviour
    {
        private Color previousColor;
        public Color currentColor;


        public void ChangeTo(Color newColor)
        {
			foreach (Renderer renderer in transform.root.GetComponentsInChildren<Renderer>())
			{
				Material mat = renderer.material;
				previousColor           = mat.color;
				renderer.material.color = newColor;
				currentColor            = newColor;
			}
		}

		public bool IsSameColour(Material a, Material b)
		{
			// TODO
			return true;
		}
    }
}