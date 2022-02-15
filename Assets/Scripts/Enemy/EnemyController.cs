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
    bool hostile;
    bool cooldown;
    bool followA;
    bool enemyIdling;
    bool walkAudio;
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
        animator.SetBool("isWalking", true);
        CheckWalkAudio(true);
    }

    private void Update() {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if(enemyIdling)
            return;
        if(hostile){
            if(transform.position.x == playerPos.x){
                if(animator.GetBool("isWalking"))
                    animator.SetBool("isWalking", false);
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.x, transform.position.y), speed * Time.deltaTime);
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
                    playerPos = other.transform.position;
                    StartCoroutine(StartRaycast());
                    enemyUI.SetStatusBar("Hostile");
                    transform.GetChild(4).GetComponent<EnemyAudio>().PlayHostile();
                }
            }
        }
    }

    IEnumerator StartRaycast()
    {
        int currentRescanCounter = rescanCounter;
        while(hostile){
            RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, detectionRange, layerMask);
            if(hitinfo){
                currentRescanCounter = rescanCounter;
                playerLocation = hitinfo.transform.position;
                enemyUI.SetStatusBar("Hostile");
                animator.SetBool("isWalking", true);
                laserGun.StartFire();
                yield return new WaitForSeconds(scanTimer);
            }
            else if(currentRescanCounter > 0){
                currentRescanCounter--;
                yield return new WaitForSeconds(scanTimer);
            }
            else{
                laserGun.StopFire();
                hostile = false;
                cooldown = true;
                StartCoroutine(StartCooldown());
            }
            
        }
    }

    IEnumerator StartCooldown()
    {
        int currentCooldownCounter = rescanCounter;
        enemyIdling = true;
        animator.SetBool("isWalking", false);
        enemyUI.SetStatusBar("Idle");
        CheckWalkAudio(false);
        while(cooldown){
            if(currentCooldownCounter > 0){
                currentCooldownCounter--;
                yield return new WaitForSeconds(scanTimer);
            }
            else{
                enemyIdling = false;
                cooldown = false;
                checkDirection();
                animator.SetBool("isWalking", true);
                CheckWalkAudio(true);
                enemyUI.SetStatusBar("Normal");
            }
            
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

    void CheckWalkAudio(bool value){
        if(walkAudio == value)
            return;
        walkAudio = value;
        if(walkAudio)
            transform.GetChild(4).GetComponent<EnemyAudio>().PlayWalingAudio(true);
        else
            transform.GetChild(4).GetComponent<EnemyAudio>().PlayWalingAudio(false);
    }
}
