using System;
using UnityEngine;

namespace Student_workspace.Dylan.Shaders
{
    public class EnemyVisionActivation : MonoBehaviour
    {
        public bool visionActivated;
        public Material visionMat;
        public Material defaultMat;

        public void Start()
        {
            VisionTestController.visionActivation += UpdateVision;
        }
        
        
        private void Update()
        {
            if(visionActivated)
            {
                GetComponent<Renderer>().material = visionMat;
            }
            else
            {
                GetComponent<Renderer>().material = defaultMat;
            }
        }

        public void UpdateVision()
        {
            visionActivated = !visionActivated;
        }
    }
}
