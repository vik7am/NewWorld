using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    LaserGunController laserGun;
    EnemyUIController enemyUI;
    Animator animator;
    Vector2 playerPos;
    [SerializeField]LayerMask layerMask;
    [SerializeField] float speed = 1f;
    [SerializeField]float detectionRange = 3.5f;
    [SerializeField]float scanTimer = 0.5f;
    [SerializeField]int rescanCounter = 3;
    Vector2 locationA, locationB, targetLocation, playerLocation;
    PlayerController player;
    public bool hostile;
    bool cooldown;
    bool followA;
    bool enemyIdling;
    bool isDirectionRight;

    private void Awake() {
        laserGun = transform.GetComponentInChildren<LaserGunController>();
        enemyUI = GetComponent<EnemyUIController>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        locationA = transform.GetChild(3).GetChild(0).position;
        locationB = transform.GetChild(3).GetChild(1).position;
    }

    private void Start() {
        isDirectionRight = true;
        targetLocation = locationB;
        StartCoroutine(StartRaycast());
    }

    private void Update() {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if(enemyIdling)
            return;
        if(hostile){
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetLocation.x, transform.position.y), speed * Time.deltaTime);
            if((Vector2)transform.position == targetLocation){
                cooldown = true;
                StartCoroutine(StartCooldown());
                followA = !followA;
                if(followA)
                    targetLocation = locationA;
                else
                    targetLocation = locationB;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && other.GetType() == typeof(CapsuleCollider2D)){
            if(hostile == false){
                if(player.IsHidden() || cooldown)
                    return;
                else{
                    hostile = true;
                    StartCoroutine(StartRaycast());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player" && other.GetType() == typeof(CapsuleCollider2D)){
            if(hostile)
                enemyIdling = true;
        }
    }

    IEnumerator StartRaycast()
    {
        int currentRescanCounter = rescanCounter;
        while(hostile){
            RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, detectionRange, layerMask);
            if(hitinfo){
                currentRescanCounter = rescanCounter;
                enemyIdling = false;
                enemyUI.SetStatusBar("Hostile");
                laserGun.StartFire();
            }
            else if(currentRescanCounter > 0){
                enemyIdling = true;
                enemyUI.SetStatusBar("Idle");
                currentRescanCounter--;
            }
            else{
                laserGun.StopFire();
                enemyIdling = false;
                hostile = false;
                checkDirection();
                enemyUI.SetStatusBar("Normal");
            }
            yield return new WaitForSeconds(scanTimer);
        }
    }

    IEnumerator StartCooldown()
    {
        int currentCooldownCounter = rescanCounter;
        while(cooldown){
            if(currentCooldownCounter > 0){
                enemyIdling = true;
                enemyUI.SetStatusBar("Idle");
                currentCooldownCounter--;
            }
            else{
                enemyIdling = false;
                cooldown = false;
                checkDirection();
                enemyUI.SetStatusBar("Normal");
            }
            yield return new WaitForSeconds(scanTimer);
        }
    }

    public void checkDirection(){
        if(transform.position.x < targetLocation.x)
            ChangeDirection(true);
        else
            ChangeDirection(false);
    }

    void ChangeDirection(bool isRight){
        if(isDirectionRight == isRight)
            return;
        if(isRight)
            transform.rotation = Quaternion.identity;
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
        isDirectionRight = isRight;
    }
}
