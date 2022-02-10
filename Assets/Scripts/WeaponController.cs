using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject bow;
    BowController bowController;
    GameObject myBow;
    PlayerUIController player;
    bool isActive;
    void Start()
    {
        player = transform.parent.GetComponent<PlayerUIController>();
    }

    void OnWeapon1(InputValue value){
        if(myBow == null)
            myBow = Instantiate(bow, transform.position, Quaternion.identity, transform);
        else
            myBow.SetActive(!myBow.activeInHierarchy);
        player.UpdateWeaponBar(myBow.activeInHierarchy);
    }
}
