using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject enemyPrefab;
    PlayerController player;
    Vector2 enemyPosition;
    float respawnCheckTimer = 2f;
    float respawnDistance = 25f;

    void Awake()
    {
        enemyPosition = FindObjectOfType<EnemyController>().transform.position;
        player = FindObjectOfType<PlayerController>();
    }

    public void EnemyDown(){
        StartCoroutine(StartRespawnProcess());
    }

    IEnumerator StartRespawnProcess()
    {
        bool respawned = false;
        while(respawned == false){
            if(Mathf.Abs(player.transform.position.x - enemyPosition.x) > respawnDistance){
                Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
                respawned = true;
            } 
            yield return new WaitForSeconds(respawnCheckTimer);
        }
        
    }
}
