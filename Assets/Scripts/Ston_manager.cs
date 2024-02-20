using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ston_maneger : MonoBehaviour
{
    public float StonDamage,LifeTime;

    public void Start()
    {
        Destroy(gameObject,LifeTime);
    }
}
