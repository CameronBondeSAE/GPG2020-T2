using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using AnthonyY;
using UnityEngine;

public class HealthPickUp : IInventoryItem
{
    public Inventory inventory;
    public string name
    {
        get { return "Health"; }
    }
    public string description { get{return "Gives you health";} }

    public override void OnPickUp()
    {
        Debug.Log("I picked up a health item");
        gameObject.SetActive(false);
    }

    public override void OnActivate()
    {
        Debug.Log("Health Activated");
        //Destroy(gameObject);
    }

    public override void OnDeActivate()
    {
        Destroy(gameObject);
        base.OnDeActivate();
    }
}
    