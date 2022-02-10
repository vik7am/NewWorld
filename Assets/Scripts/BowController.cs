using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowController : MonoBehaviour
{
    [SerializeField]GameObject arrow;
    [SerializeField]float arrowSpeed = 5f;
    [SerializeField]float arrowLife = 2f;
    PlayerInventoryController inventory;

    private void Start() {
        inventory = transform.parent.parent.GetComponent<PlayerInventoryController>();
    }

    void OnFire(InputValue value){
        if(inventory.RemoveArrow(1))
            FireArrow();
    }

    void FireArrow()
    {
        Vector2 firePos = transform.GetChild(0).position;
        Vector2 direction = transform.parent.parent.localScale;
        GameObject currentArrow = Instantiate(arrow, firePos, Quaternion.identity);
        currentArrow.transform.localScale = direction;
        Rigidbody2D rb = currentArrow.GetComponent<Rigidbody2D>();
        if(rb != null)
            rb.velocity = transform.right * arrowSpeed * direction.x;
        Destroy(currentArrow, arrowLife);
    }
}
