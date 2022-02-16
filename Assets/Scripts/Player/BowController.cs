using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowController : MonoBehaviour
{
    [SerializeField]GameObject arrow;
    [SerializeField]float arrowSpeed = 5f;
    [SerializeField]float arrowLife = 2f;
    GameUIController gameUI;
    InventoryController inventory;

    void Awake() {
        inventory = FindObjectOfType<InventoryController>();
        gameUI = FindObjectOfType<GameUIController>();
    }

    void OnFire(InputValue value){
        if(inventory.RemoveArrow(1)){
            FireArrow();
            gameUI.UpdateWeaponBar();
        }     
    }

    public void AndroidFireArrow(){
        if(inventory.RemoveArrow(1)){
            FireArrow();
            gameUI.UpdateWeaponBar();
        } 
    }

    void FireArrow()
    {
        Vector2 firePos = transform.GetChild(0).position;
        GameObject currentArrow = Instantiate(arrow, firePos, transform.rotation);
        Rigidbody2D rb = currentArrow.GetComponent<Rigidbody2D>();
        if(rb != null)
            rb.velocity = transform.right * arrowSpeed;
        Destroy(currentArrow, arrowLife);
    }
}
