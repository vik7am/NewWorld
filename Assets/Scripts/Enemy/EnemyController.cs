using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Pathfinder pathfinder;
    LaserGunController laserGun;
    EnemyUIController enemyUI;
    Animator animator;

    private void Awake() {
        pathfinder = GetComponent<Pathfinder>();
        laserGun = transform.GetComponentInChildren<LaserGunController>();
        enemyUI = GetComponent<EnemyUIController>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && other.GetType() == typeof(CapsuleCollider2D)){
            if(other.GetComponent<PlayerController>().IsHidden())
                return;
            laserGun.StartFire();
            if(pathfinder.IsIdle()){
                pathfinder.CancelIdle();
                }
            pathfinder.followPlayer = true;
            enemyUI.SetStatusBar("Hostile");
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player" && other.GetType() == typeof(CapsuleCollider2D)){
            if(other.GetComponent<PlayerController>().IsHidden())
                return;
            laserGun.StopFire();
            pathfinder.followPlayer = false;
            pathfinder.SetIdle();
            
        }
    }
}
