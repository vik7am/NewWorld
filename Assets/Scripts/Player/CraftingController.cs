using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingController : MonoBehaviour
{
    [SerializeField]int arrowPackSize = 10;
    InventoryController inventory;
    CraftingUIController craftingUI;
    GameUIController gameUI;
    
    void Awake()
    {
        inventory = FindObjectOfType<InventoryController>();
        craftingUI = FindObjectOfType<CraftingUIController>();
        gameUI = FindObjectOfType<GameUIController>();
    }

    public void Craft(){
        if(craftingUI.gameObject.activeInHierarchy == false)
            return;
        if(inventory.GetRidgeWood() >=2 && inventory.GetMetalShards() >=1){
            inventory.RemoveMetalShards(1);
            inventory.RemoveRidgeWoods(2);
            inventory.AddArrow(arrowPackSize);
            craftingUI.UpdateUI();
            gameUI.UpdateWeaponBar();
        }
    }
}
