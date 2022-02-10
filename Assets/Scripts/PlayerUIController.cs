using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField]Slider healthBar;
    [SerializeField]GameObject weaponBar;
    [SerializeField]GameObject inventory;
    [SerializeField]GameObject gameUI;
    bool displayInventory;

    private void Start() {
        weaponBar.SetActive(false);
    }

    public void UpdateHp(float hp){
        healthBar.value = hp;
    }

    public void UpdateWeaponBar(bool isVisible){
        if(isVisible)
            weaponBar.SetActive(true);
        else
            weaponBar.SetActive(false);
    }

    void OnInventory(InputValue value){
        gameUI.SetActive(displayInventory);
        displayInventory = !displayInventory;
        inventory.SetActive(displayInventory);
        if(displayInventory)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
