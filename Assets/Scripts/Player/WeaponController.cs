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
    Animator animator;
    bool isActive;
    void Start()
    {
        player = transform.parent.GetComponent<PlayerUIController>();
        animator = transform.parent.GetComponent<Animator>();
    }

    void OnWeapon1(InputValue value){
        if(myBow == null)
            myBow = Instantiate(bow, transform.position, Quaternion.identity, transform);
        else
            myBow.SetActive(!myBow.activeInHierarchy);
        player.UpdateWeaponBar(myBow.activeInHierarchy);
        animator.SetBool("isFighting", myBow.activeInHierarchy);
    }
}
