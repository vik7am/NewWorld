using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Pathfinder pathfinder;
    LaserGunController laserGun;
    
    void Start()
    {
        pathfinder = GetComponent<Pathfinder>();
        laserGun = transform.GetComponentInChildren<LaserGunController>();   
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            laserGun.StartFire();
            if(pathfinder.IsIdle()){
                pathfinder.CancelIdle();
                }
            pathfinder.followPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            laserGun.StopFire();
            pathfinder.followPlayer = false;
            pathfinder.SetIdle();
        }
    }
}
