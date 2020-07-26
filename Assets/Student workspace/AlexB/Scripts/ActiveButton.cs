using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

namespace AJ
{
    public class UIButton : MonoBehaviour
    {
        public GameObject Button;


        public void Enable()
        {
            Button.SetActive(true);
        }

        public void Disable()
        {
            Button.SetActive(false);

        }
    }
}