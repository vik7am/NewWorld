using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeponController : MonoBehaviour
{
    BowController bowController;
    bool isActive;
    void Start()
    {
        bowController = FindObjectOfType<BowController>();
        bowController.gameObject.SetActive(false);
    }

    void OnWepon1(InputValue value){
        Debug.Log("Weapon out");
        isActive = bowController.gameObject.activeInHierarchy;
        bowController.gameObject.SetActive(!isActive);
    }
}
