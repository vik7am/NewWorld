using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    string itemText;
    InventoryController inventory;
    InventoryUIController inventoryUI;
    PlayerHealth health;
    GameObject itemObject;
    bool isCollectable;
    bool isKillable;
    int itemType;
    GameUIController gameUI;

    private void Awake() {
        inventory = FindObjectOfType<InventoryController>();
        inventoryUI = FindObjectOfType<InventoryUIController>();
        gameUI = FindObjectOfType<GameUIController>();
        health = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Item"){
            itemObject = other.gameObject;
            Collectablecontroller item = other.GetComponent<Collectablecontroller>();
            itemText = item.GetItemText();
            itemType = item.GetItemType();
            gameUI.DisplayCollectableBar(itemText);
            isCollectable = true;
        }
        else if(other.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider2D)){
            itemObject = other.gameObject;
            if(!itemObject.GetComponent<EnemyUIController>().IsHostile()){
                gameUI.DisplayCollectableBar("Silent Strike");
                isKillable = true;
            }
        }
    }

    void OnInteract(InputValue value){
        if(isCollectable){
            if(itemType == 1)
                inventory.AddRidgeWoods(5);
            if(itemType == 2)
                inventory.AddMetalShards(5);
            if(itemType == 3)
                if(!health.FillMedicinePouch(20))
                    return;
            Destroy(itemObject);
            inventoryUI.UpdateUI();
        }
        if(isKillable){
            if(!itemObject.GetComponent<EnemyUIController>().IsHostile())
                itemObject.GetComponent<EnemyHealth>().ReduceHp(100f);
                
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
            gameUI.HideCollectableBar();
            isCollectable = false;
            isKillable = false;
            itemObject = null;
    }
}
