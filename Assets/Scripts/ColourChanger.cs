using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace AJ
{
	public class ColourChanger : NetworkBehaviour
    {
        private Color previousColor;
        public Color currentColor;

        [ClientRpc]
        public void RpcChangeTo(Color newColor)
        {
	        foreach (Renderer renderer in transform.GetComponentsInChildren<Renderer>())
	        {
		        Material mat = renderer.material;
		        previousColor           = mat.color;
		        renderer.material.color = newColor;
		        currentColor            = newColor;
	        }
	        
        }
        

        public void ChangeTo(Color newColor)
        {
	        if (isServer)
	        {
		        RpcChangeTo(newColor);
	        }
        }

		public bool IsSameColour(Material a, Material b)
		{
			// TODO
			return true;
		}
    }
}