using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectablecontroller : MonoBehaviour
{
    [SerializeField]bool isridgeWood;
    [SerializeField]bool ismetalShard;
    [SerializeField]bool ismedicinePlant;
    //int size = 5;

    public string GetItemText(){
        if(isridgeWood)
            return "E - Gather Ridge-wood";
        if(ismetalShard)
            return "E - Gather Metal Shard";
        if(ismedicinePlant)
            return "E - Gather Medicinal Plant";
        return "Nothing";
    }

    public int GetItemType()
    {
        if(isridgeWood)
            return 1;
        if(ismetalShard)
            return 2;
        if(ismedicinePlant)
            return 3;
        return 0;
    }

    /*
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            //PlayerInventoryController inventory = other.GetComponent<PlayerInventoryController>();
            PlayerUIController player = other.GetComponent<PlayerUIController>();
            if(isridgeWood){
                player.ShowCollectableInfo("Gather Ridge-wood", GetItemType());
                //isCollectable = true;
                //inventory.AddRidgeWoods(size);
            }
            if(isridgeWood){
                player.ShowCollectableInfo("Gather Metal Shard", GetItemType());
                //isCollectable = true;
                //inventory.AddMetalShards(size);
            }
            //Destroy(gameObject);
        }
    }
    
    private int GetItemType()
    {
        if(isridgeWood)
            return 1;
        if(ismetalShards)
            return 2;
        return 0;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerUIController player = other.GetComponent<PlayerUIController>();
            player.HideCollectableInfo();
        }
    }**/
}
