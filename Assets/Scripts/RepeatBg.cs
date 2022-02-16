using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBg : MonoBehaviour
{
    //BoxCollider2D boxCollider2D;
    Rigidbody2D rb;
    [SerializeField]float width = 57.6f;
    [SerializeField]float speed = -3f;

    void Awake()
    {
        //boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Start()
    {
        //width = boxCollider2D.size.x;
        rb.velocity = new Vector2(speed, 0);
        
    }

    void Update(){
        if(transform.position.x < -width){
            Repostition();
        }
    }

    void Repostition(){
        Vector2 vector = new Vector2(width * 2, 0);
        transform.position = (Vector2) transform.position + vector;
    }
}
