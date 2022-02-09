using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]float hp = 100f;
    [SerializeField]bool isPlayer;
    PlayerUIController playerUI;
    EnemyUIController enemyUI;
    float MaxHP;


    private void Start() {
        MaxHP = hp;
        playerUI = GetComponent<PlayerUIController>();
        enemyUI = GetComponent<EnemyUIController>();
    }

    public float GetHp(){
        return hp;
    }

    public void ReduceHp(float value){
        hp -= value;
        if(isPlayer)
            playerUI.UpdateHp(hp);
        else
            enemyUI.UpdateHp(hp, MaxHP);
        if(hp <= 0)
            Destroy(gameObject);
    }
}
