using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]float speed = 1f;
    Rigidbody2D enemyRigidbody2D;
    
    void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("Player found");
            enemyRigidbody2D.velocity = new Vector2(-speed, 0f);
        }
    }
     private void OnTriggerExit2D(Collider2D other) {
         if(other.tag == "Player"){
            Debug.Log("Player lost");
            enemyRigidbody2D.velocity = new Vector2(0f, 0f);
         }
     }
}
