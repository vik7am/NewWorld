using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    BowController bowController;
    bool isActive;
    void Start()
    {
        bowController = FindObjectOfType<BowController>();
        bowController.gameObject.SetActive(false);
    }

    void OnWeapon1(InputValue value){
        isActive = bowController.gameObject.activeInHierarchy;
        bowController.gameObject.SetActive(!isActive);
    }
}
