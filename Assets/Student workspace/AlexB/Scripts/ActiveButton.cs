using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

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
