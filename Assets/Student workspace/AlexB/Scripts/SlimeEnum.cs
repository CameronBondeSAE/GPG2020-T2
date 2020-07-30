using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class SlimeEnum : MonoBehaviour
    {
        public enum ColorType
        {
            Red,
            Green,
            Pink,
            Orange
        }

        public ColorType currentColorType;

        void Start()
        {
            currentColorType = ColorType.Green;
        }

        void Update()
        {
            switch(currentColorType)
            {
                case ColorType.Green:
                    Debug.Log("Green");
                    break;
                case ColorType.Red:
                    Debug.Log("Red");
                    break;
                case ColorType.Orange:
                    Debug.Log("Orange");
                    break;
                case ColorType.Pink:
                    Debug.Log("Pink");
                    break;
            }
        }

        public static implicit operator Color(SlimeEnum v)
        {
            throw new NotImplementedException();
        }
    }
}
