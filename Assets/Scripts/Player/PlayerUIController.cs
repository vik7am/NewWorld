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
    [SerializeField]Text text;
    [SerializeField]Text collectableBar;
    PlayerInventoryController inventoryController;
    int collectableItemtype = 0;
    bool isCollectable;
    bool displayInventory;

    private void Start() {
        weaponBar.SetActive(false);
        inventoryController = GetComponent<PlayerInventoryController>();
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
        if(displayInventory){
            inventoryController.updateInventory();
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    public void ShowCollectableInfo(string text){
        collectableBar.transform.parent.gameObject.SetActive(true);
        collectableBar.text = text;
    }

    public void HideCollectableInfo(){
        collectableBar.transform.parent.gameObject.SetActive(false);
    }

    public void UpdateAmmunationCounter(int value){
        text.text = value.ToString();
    }
}
