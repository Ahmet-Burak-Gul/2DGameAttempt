using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public bool deadh = false;

    Transform muzzle;

    public Transform Ston;
    public float stonSpeed;

    public Slider slider;

    bool mouseIsNotOvertUI;
    public void Start()
    {
        muzzle = transform.GetChild(0);
        slider.maxValue = health;
        slider.value = health;
    }

    public void Update()
    {
        mouseIsNotOvertUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.GetMouseButtonDown(0) && mouseIsNotOvertUI)
        {
            ShootSton();
        }
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
            deadh = true;
        }
        slider.value = health;
    }

    void ShootSton()
    {
        Transform tempSton;
        tempSton = Instantiate(Ston, muzzle.position, Quaternion.identity);
        tempSton.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * stonSpeed);
        DataManager.instance.ShotSton++;
    }
}
