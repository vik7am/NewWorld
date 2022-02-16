using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 2.5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField]LayerMask groundLayer;
    Vector2 moveInput;
    Rigidbody2D myrigidbody;
    Animator animator;
    GameUIController gameUI;
    Transform groundCheck;
    AudioSource audioSource;
    PlayerAudio playerAudio;
    CapsuleCollider2D feet;
    UIController ui;
    bool playerDown;
    bool walkAudio = true;
    bool hidden;
    bool isGrounded;

    void Awake()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameUI = FindObjectOfType<GameUIController>();
        groundCheck = transform.GetChild(3);
        audioSource = GetComponent<AudioSource>();
        playerAudio = FindObjectOfType<PlayerAudio>();
        feet = GetComponent<CapsuleCollider2D>();
        ui = FindObjectOfType<UIController>();
        
    }

    void Update()
    {
        if(playerDown)
            return;
        Run();
        ChangeDirection();
        CheckLave();
    }

    private void CheckLave()
    {
        if(feet.IsTouchingLayers(LayerMask.GetMask("Lava")))
            GetComponent<PlayerHealth>().ReduceHealth(100);
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value){
        if(playerDown)
            return;
        if(!feet.IsTouchingLayers(LayerMask.GetMask("Ground", "Water", "Lava")))
            return;
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if(value.isPressed){
            myrigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnMainMenu(InputValue value){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
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
        if(isMoving)
            CheckWalkAudio(true);
        else
            CheckWalkAudio(false);
    }

    void CheckWalkAudio(bool value){
        if(walkAudio == value)
            return;
        walkAudio = value;
        if(walkAudio)
            playerAudio.PlayWalingAudio(true);
        else
            playerAudio.PlayWalingAudio(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {  
        if(other.tag == "Grass"){
            gameUI.PlayerVisibility(false);
            hidden = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Grass"){
            gameUI.PlayerVisibility(true);
            hidden = false;
        }
    }

    public bool IsHidden(){
        return hidden;
    }

    public void PlayerDown(){
        playerDown = true;
    }

    void OnInventory(InputValue value){
        ui.NewOnInventory();
    }

    void OnCrafting(InputValue value){
        ui.NewOnCrafting();
    }

}
