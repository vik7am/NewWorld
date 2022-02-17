using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{
    PlayerController player;
    WeaponController weapon;
    PlayerHealth health;
    CraftingController crafting;
    PlayerInteractionController interact;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        weapon = FindObjectOfType<WeaponController>();
        health = FindObjectOfType<PlayerHealth>();
        crafting = FindObjectOfType<CraftingController>();
        interact = FindObjectOfType<PlayerInteractionController>();
    }

    void OnMove(InputValue value){
        player.Move(value.Get<Vector2>());
    }

    void OnInteract(InputValue value){
        interact.Interact();
    }

    void OnFire(InputValue value){
        weapon.FireBow();
    }

    void OnJump(InputValue value){
        player.Jump();
    }

    void OnWeapon1(InputValue value){
        weapon.Weapon1();
    }

    void OnHeal(InputValue value){
        health.Heal();
    }

    void OnCraft(InputValue value){
        crafting.Craft();
    }

    void OnInventory(InputValue value){
        player.Inventory();
    }

    void OnCrafting(InputValue value){
        player.Crafting();
    }

    public void OnMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
