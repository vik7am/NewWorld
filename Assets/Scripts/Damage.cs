using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]float damage = 25f;

    public float GetDamage(){
        return damage;
    }
}
