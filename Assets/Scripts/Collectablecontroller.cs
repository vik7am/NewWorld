using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectablecontroller : MonoBehaviour
{
    int arrowPackSize = 5;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerInventoryController inventory = other.GetComponent<PlayerInventoryController>();
            inventory.AddArrow(arrowPackSize);
            Destroy(gameObject);
        }
    }
}
