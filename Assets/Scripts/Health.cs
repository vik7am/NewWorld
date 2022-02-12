using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]float hp = 100f;
    [SerializeField]bool isPlayer;
    [SerializeField]GameObject deathbox;
    GameUIController gameUI;
    EnemyUIController enemyUI;
    float MaxHP;

    private void Awake() {
        gameUI = FindObjectOfType<GameUIController>();
        enemyUI = GetComponent<EnemyUIController>();
    }

    private void Start() {
        MaxHP = hp;
    }

    public float GetHp(){
        return hp;
    }

    public void ReduceHp(float value){
        hp -= value;
        if(isPlayer)
            gameUI.UpdateHealthBar(hp);
        else
            enemyUI.UpdateHp(hp, MaxHP);
        if(hp <= 0){
            Destroy(gameObject);
            if(!isPlayer){
                Instantiate(deathbox, transform.position, Quaternion.identity);
            }
        }
            
    }
}
