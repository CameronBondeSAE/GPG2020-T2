using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class Rotate : MonoBehaviour
    {

        void Update()
        {
            transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
        }
    }
}