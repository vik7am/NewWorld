using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 5f;
    PlayerController player;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        arrowSpeed *= Mathf.Sign(player.transform.localScale.x);
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        transform.position = new Vector2(transform.position.x + arrowSpeed*Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider2D)){
            other.GetComponent<Health>().ReduceHp(GetComponent<Damage>().GetDamage());
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
