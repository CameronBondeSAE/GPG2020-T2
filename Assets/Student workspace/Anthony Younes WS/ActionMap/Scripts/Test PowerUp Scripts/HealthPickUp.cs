using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;

public class HealthPickUp : MonoBehaviour,IInventoryItem
{
    public string name
    {
        get { return "Health"; }
    }
    public string description { get{return "Gives you health";} }

    public void OnPickUp()
    {
        Debug.Log("I picked up a health item");
        gameObject.SetActive(false);
    }

    public void OnActivate()
    {
        Debug.Log("Health Activated");
        //Destroy(gameObject);

    }
}
