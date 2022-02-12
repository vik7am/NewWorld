using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && other.GetType() == typeof(CapsuleCollider2D)){
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            Damage damage = GetComponent<Damage>();
            if(health == null)
                Debug.Log("Health null");
            if(damage == null)
                Debug.Log("damage null");
            health.ReduceHealth(damage.GetDamage());
            Destroy(gameObject);
        }
        if(other.tag == "Arrow"){
            Destroy(gameObject);
        }
    }
}
