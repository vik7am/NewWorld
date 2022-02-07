using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]float hp = 100f;

    public float GetHp(){
        return hp;
    }

    public void ReduceHp(float value){
        hp -= value;
        if(hp <= 0)
            Destroy(gameObject);
    }
}
