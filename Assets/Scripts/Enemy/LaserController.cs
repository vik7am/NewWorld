using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && other.GetType() == typeof(CapsuleCollider2D)){
            other.GetComponent<Health>().ReduceHp(GetComponent<Damage>().GetDamage());
            Destroy(gameObject);
        }
        if(other.tag == "Arrow"){
            Destroy(gameObject);
        }
    }
}
