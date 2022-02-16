using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider2D)){
            other.GetComponent<EnemyHealth>().ReduceHp(GetComponent<Damage>().GetDamage());
            Destroy(gameObject);
        }
        if(other.tag == "Laser"){
            Destroy(gameObject);
        }
        if(other.tag == "Platform"){
            Destroy(gameObject);
        }
    }
}
