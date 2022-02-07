using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 5f;

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        transform.position = new Vector2(transform.position.x + arrowSpeed*Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
