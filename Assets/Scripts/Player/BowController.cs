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

    void FireArrow()
    {
        Vector2 firePos = transform.GetChild(0).position;
        //Vector2 direction = transform.parent.parent.localScale;
        GameObject currentArrow = Instantiate(arrow, firePos, transform.rotation);
        //currentArrow.transform.localScale = direction;
        Rigidbody2D rb = currentArrow.GetComponent<Rigidbody2D>();
        if(rb != null)
            rb.velocity = transform.right * arrowSpeed /*** direction.x**/;
        Destroy(currentArrow, arrowLife);
    }
}
