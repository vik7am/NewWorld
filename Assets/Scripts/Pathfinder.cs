using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField]float speed = 2f;
    [SerializeField]Transform a;
    [SerializeField]Transform b;
    bool isFirstTarget;
    bool isIdle;
    public bool followPlayer;
    bool isDirectionRight;
    Transform target;
    PlayerController player;
    Coroutine coroutine;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
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
        if(isDirectionRight != isRight)
            transform.localScale = new Vector2(transform.localScale.x * -1f, 1f);
        isDirectionRight = isRight;
    }

    public void checkDirection(){
        if(transform.position.x < target.position.x)
            ChangeDirection(true);
        else
            ChangeDirection(false);
    }

    void Move()
    {
        if(followPlayer)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        if(transform.position == target.position){
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
        coroutine = null;
    }

    IEnumerator Scan()
    {
        isIdle = true;
        yield return new WaitForSecondsRealtime(2);
        isIdle = false;
        checkDirection();
        coroutine = null;
    }

    public Boolean IsIdle(){
        if(coroutine != null)
            return true;
        else
            return false;
    }
}
