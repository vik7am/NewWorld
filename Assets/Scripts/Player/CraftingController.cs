using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingController : MonoBehaviour
{
    [SerializeField]int arrowPackSize = 10;
    InventoryController inventory;
    CraftingUIController craftingUI;
    

    void Awake()
    {
        inventory = FindObjectOfType<InventoryController>();
        craftingUI = FindObjectOfType<CraftingUIController>();
    }

    void OnCraft(InputValue value){
        if(inventory.GetRidgeWood() >=2 && inventory.GetMetalShards() >=1){
            inventory.RemoveMetalShards(1);
            inventory.RemoveRidgeWoods(2);
            inventory.AddArrow(arrowPackSize);
            craftingUI.UpdateUI();
        }
    }
}
