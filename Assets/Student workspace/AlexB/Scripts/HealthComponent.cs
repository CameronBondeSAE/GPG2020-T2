using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float currMaxHealth;
    public float currMinHealth;
    public float currHealth;

    public void AddHp()
    {
        currHealth++;
    }

    public void TakeHp()
    {
        currHealth--;
    }
}
