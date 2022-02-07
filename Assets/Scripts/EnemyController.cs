using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]float speed = 1f;
    Rigidbody2D enemyRigidbody2D;
    Pathfinder pathfinder;
    
    void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        pathfinder = GetComponent<Pathfinder>();
    }

    float GetSpeed(){
        return speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(pathfinder.IsIdle()){
                pathfinder.CancelIdle();
                }
            pathfinder.followPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            pathfinder.followPlayer = false;
            pathfinder.SetIdle();

        }
    }
}
