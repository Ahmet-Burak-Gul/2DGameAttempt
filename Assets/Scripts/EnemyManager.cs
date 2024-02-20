using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    bool colliderBusy = false;

    public Slider slider;

    public void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !colliderBusy)
        {
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }        
        else if(other.tag == "Ston")
        {
            GetDamage(other.GetComponent<Ston_maneger>().StonDamage);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        colliderBusy = false;
    }

    public void GetDamage(float damege)
    {
        if ((health - damege) > 0)
        {
            health -= damege;
        }
        else
        {
            health = 0;
            DataManager.instance.EnemyKilled++;
            Destroy(gameObject);
        }
        slider.value = health;
    }
}
