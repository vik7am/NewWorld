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
    bool isActive;
    void Start()
    {
        // bowController = FindObjectOfType<BowController>();
        // bowController.gameObject.SetActive(false);
    }

    void OnWeapon1(InputValue value){
        if(myBow == null)
            myBow = Instantiate(bow, transform.position, Quaternion.identity, transform);
        else
            myBow.SetActive(!myBow.activeInHierarchy);
        
        // isActive = bowController.gameObject.activeInHierarchy;
        // bowController.gameObject.SetActive(!isActive);
    }
}
