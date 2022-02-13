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
    bool bowEquipped;
    GameUIController gameUI;

    Animator animator;
    bool isActive;
    void Awake()
    {
        gameUI = FindObjectOfType<GameUIController>();
        animator = transform.parent.GetComponent<Animator>();
    }

    void OnWeapon1(InputValue value){
        if(myBow == null){
            myBow = Instantiate(bow, transform.position, transform.rotation, transform);
        }
        if(bowEquipped){
            bowEquipped = false;
            gameUI.HideWeaponBar();
            myBow.SetActive(false);
            animator.SetBool("isFighting", false);
        }
        else{
            bowEquipped = true;
            gameUI.DisplayWeaponBar();
            myBow.SetActive(true);
            animator.SetBool("isFighting", true);
        }
    }
}
