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
    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        weapon = FindObjectOfType<WeaponController>();
        health = FindObjectOfType<PlayerHealth>();
        crafting = FindObjectOfType<CraftingController>();
        interact = FindObjectOfType<PlayerInteractionController>();
    }

    public void KeyHoldA(){
        player.Move(new Vector2(-1, 0));
    }

    public void KeyReleasedA(){
        player.Move(new Vector2(0, 0));
    }

    public void KeyHoldD(){
        player.Move(new Vector2(1, 0));
    }

    public void KeyReleasedD(){
        player.Move(new Vector2(0, 0));
    }

    public void KeyPressedE(){
        interact.Interact();
    }

    public void KeyPressedX(){
        weapon.FireBow();
    }

    public void KeyHoldSpace(){
        player.Jump();
    }

    public void KeyPressed1(){
        weapon.Weapon1();
    }

    public void KeyPressedH(){
        health.Heal();
    }

    public void KeyPressedF(){
        crafting.Craft();
    }

    public void KeyPressedI(){
        player.Inventory();
    }

    public void KeyPressedK(){
        player.Crafting();
    }

    public void KeyPressedQ(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
}
