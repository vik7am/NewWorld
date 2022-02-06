using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D myrigidbody;
    Animator animator;

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        ChangeDirection();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value){
        if(value.isPressed){
            myrigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnExitGame(InputValue value){
        Application.Quit();
    }

    void Run(){
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVelocity;
    }

    void ChangeDirection(){
        bool isMoving = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isWalking", isMoving);
        if(isMoving)
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody.velocity.x), 1f);
    }
}
