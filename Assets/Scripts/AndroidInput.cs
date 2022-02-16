using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidInput : MonoBehaviour
{
    PlayerController player;
    WeaponController weapon;
    PlayerHealth health;
    CraftingController crafting;
    PlayerInteractionController interact;
    //BowController bow;
    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        weapon = FindObjectOfType<WeaponController>();
        health = FindObjectOfType<PlayerHealth>();
        crafting = FindObjectOfType<CraftingController>();
        interact = FindObjectOfType<PlayerInteractionController>();
        //bow = FindObjectOfType<BowController>();
    }

    void Update()
    {
        
    }

    public void StartLeft(){
        player.AndroidMove(new Vector2(-1, 0));
    }

    public void StartRight(){
        player.AndroidMove(new Vector2(1, 0));
    }

    public void StopMovement(){
        player.AndroidMove(new Vector2(0, 0));
    }

    public void Interact(){
        interact.AndroidInteract();
    }

    /*public void InitializeBow(BowController value){
        bow = value;
    }*/

    public void FireArrow(){
        weapon.AndroidFireBow();
    }

    public void Jump(){
        player.AndroidJump();
    }

    public void EquipWeapon(){
        weapon.AndroidWeapon();
    }

    public void Heal(){
        health.AndroidHeal();
    }

    public void CraftArrows(){
        crafting.AndroidCraft();
    }

    public void Inventory(){
        player.AndroidInventory();
    }

    public void CraftingMenu(){
        player.AndroidCrafting();
    }

    public void ExitMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
}
