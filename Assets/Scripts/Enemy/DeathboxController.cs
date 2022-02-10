using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathboxController : MonoBehaviour
{
    int metalShards = 5;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerInventoryController inventory = other.GetComponent<PlayerInventoryController>();
            inventory.AddMetalShards(metalShards);
            Destroy(gameObject);
        }
    }
}
