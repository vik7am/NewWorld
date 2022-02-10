using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    string itemText;
    PlayerUIController playerUI;
    PlayerInventoryController inventory;
    GameObject item;
    bool isCollectable;
    int itemType;

    private void Start() {
        playerUI = GetComponent<PlayerUIController>();
        inventory = GetComponent<PlayerInventoryController>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        item = other.gameObject;
        if(other.tag == "Item"){
            //PlayerInventoryController inventory = other.GetComponent<PlayerInventoryController>();
            Collectablecontroller item = other.GetComponent<Collectablecontroller>();
            itemText = item.GetItemText();
            itemType = item.GetItemType();
            playerUI.ShowCollectableInfo(itemText);
            isCollectable = true;
            //Destroy(gameObject);
        }
    }

    void OnInteract(InputValue value){
        if(isCollectable){
            if(itemType == 1)
                inventory.AddRidgeWoods(5);
            if(itemType == 2)
                inventory.AddMetalShards(5);
            Destroy(item);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        playerUI.HideCollectableInfo();
        isCollectable = false;
        item = null;
    }
}
