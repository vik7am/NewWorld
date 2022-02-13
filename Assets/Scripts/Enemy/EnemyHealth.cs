using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]float hp = 100f;
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
            enemyUI.UpdateHp(hp, MaxHP);
        if(hp <= 0){
            Destroy(gameObject);
            Instantiate(deathbox, transform.position, Quaternion.identity);
        }
        else
            transform.GetChild(4).GetComponent<EnemyAudio>().PlayArrowHit();
    }
}
