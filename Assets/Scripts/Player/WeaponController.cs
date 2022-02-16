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
    //AndroidInput android;

    Animator animator;
    bool isActive;
    void Awake()
    {
        gameUI = FindObjectOfType<GameUIController>();
        animator = transform.parent.GetComponent<Animator>();
        //android = FindObjectOfType<AndroidInput>();
    }

    private void Start() {
        //myBow = Instantiate(bow, transform.position, transform.rotation, transform);
        //android.InitializeBow(myBow.GetComponent<BowController>());
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

    public void AndroidWeapon(){
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

    public void AndroidFireBow(){
        if(bowEquipped){
            myBow.GetComponent<BowController>().AndroidFireArrow();
        }
    }
}
