using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 2.5f;
    [SerializeField] float jumpSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D myrigidbody;
    Animator animator;
    GameUIController gameUI;
    bool hidden;

    void Awake()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameUI = FindObjectOfType<GameUIController>();
    }

    void FixedUpdate()
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
            transform.rotation = myrigidbody.velocity.x > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {  
        if(other.tag == "Grass"){
            //Debug.Log("Hidden");
            gameUI.PlayerVisibility(false);
            hidden = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Grass"){
            //Debug.Log("Visible");
            gameUI.PlayerVisibility(true);
            hidden = false;
        }
    }

    public bool IsHidden(){
        return hidden;
    }
}
