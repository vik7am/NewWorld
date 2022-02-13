using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField]float speed = 2f;
    Vector2 a, b, target;
    //Transform a, b;
    //Transform b;
    bool isFirstTarget;
    bool isIdle;
    public bool followPlayer;
    bool isDirectionRight;
    //Transform target;
    PlayerController player;
    Coroutine coroutine;
    Animator animator;
    EnemyUIController enemyUI;
    bool walkAudio;
    AudioSource audioSource;

    private void Awake() {
        player = FindObjectOfType<PlayerController>();
        enemyUI = GetComponent<EnemyUIController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        a = transform.GetChild(3).GetChild(0).position;
        b = transform.GetChild(3).GetChild(1).position;
    }

    private void Start() {
        animator.SetBool("isWalking", true);
        isDirectionRight = true;
        target = b;
        checkDirection();
    }

    void Update() {
        if(!isIdle)
            Move();
    }

    void SwitchTarget(){
        if(isFirstTarget)
            target = b;
        else
            target = a;
        isFirstTarget = !isFirstTarget;
    }

    void ChangeDirection(bool isRight){
        if(isDirectionRight == isRight)
            return;
        if(isRight)
            transform.rotation = Quaternion.identity;
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
        isDirectionRight = isRight;
        /**if(isDirectionRight != isRight)
            transform.localScale = new Vector2(transform.localScale.x * -1f, 1f);
        isDirectionRight = isRight;*/
    }

    public void checkDirection(){
        if(transform.position.x < target.x)
            ChangeDirection(true);
        else
            ChangeDirection(false);
    }

    void Move()
    {
        if(player == null)
            followPlayer = false;
        if(followPlayer)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.x, transform.position.y), speed * Time.deltaTime);
        if((Vector2)transform.position == target){
            SwitchTarget();
            SetIdle();
        }
    }

    public void SetIdle(){
        coroutine = StartCoroutine(Scan());
    }

    public void CancelIdle(){
        StopCoroutine(coroutine);
        isIdle = false;
        animator.SetBool("isWalking", true);
        CheckWalkAudio(true);
        enemyUI.SetStatusBar("Hostile");
        coroutine = null;
    }

    IEnumerator Scan()
    {
        isIdle = true;
        enemyUI.SetStatusBar("Idle");
        animator.SetBool("isWalking", false);
        CheckWalkAudio(false);
        yield return new WaitForSeconds(2);
        animator.SetBool("isWalking", true);
        CheckWalkAudio(true);
        isIdle = false;
        enemyUI.SetStatusBar("Normal");
        checkDirection();
        coroutine = null;
    }

    public Boolean IsIdle(){
        if(coroutine != null)
            return true;
        else
            return false;
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
