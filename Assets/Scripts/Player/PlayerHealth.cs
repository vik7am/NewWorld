using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]float playerHealth = 100f;
    float medicinePouch = 0f;
    float health;
    GameUIController gameUI;
    Animator animator;

    private void Awake() {
        gameUI = FindObjectOfType<GameUIController>();
        animator = GetComponent<Animator>();
    }

    private void Start() {
        health = playerHealth;
    }

    public bool FillMedicinePouch(float value){
        if(medicinePouch == 100f)
            return false;
        medicinePouch += value;
        Mathf.Clamp(medicinePouch, 0f, 100f);
        gameUI.UpdateMedicineBar(medicinePouch);
        FindObjectOfType<PlayerAudio>().PlayMedicinalPlant();
        return true;
    }

    public void OnHeal(InputValue value){
        if(health == playerHealth || medicinePouch == 0)
            return;
        float requiredHealing = playerHealth - health;
        if(medicinePouch >= requiredHealing){
            health = playerHealth;
            medicinePouch -= requiredHealing;
        }
        else{
            health += medicinePouch;
            medicinePouch = 0f;
        }
        gameUI.UpdateHealthBar(health);
        gameUI.UpdateMedicineBar(medicinePouch);
    }

    public void IncreseHp(float value){
        health += value;
        Mathf.Clamp(health, 0f, 100f);
    }

    public void ReduceHealth(float value){
        health -= value;
        Mathf.Clamp(health, 0f, 100f);
        gameUI.UpdateHealthBar(health);
        if(health <= 0){
            PlayerDead();
            
            //Destroy(gameObject, 3f);
        }
    }

    public void PlayerDead(){
        animator.SetBool("isDown", true);
        GetComponent<PlayerController>().PlayerDown();
        Invoke("RestartGame", 3f);
    }

    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
