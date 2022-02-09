using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField]Slider healthBar;

    public void UpdateHp(float hp){
        healthBar.value = hp;
    }
}
