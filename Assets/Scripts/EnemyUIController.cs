using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField]float HPDisplayTime;
    GameObject healthBar;
    Coroutine coroutine;
    bool showHealthBar;

    private void Start() {
        healthBar = transform.GetChild(1).gameObject;
        healthBar.SetActive(false);
    }

    public void UpdateHp(float hp, float MaxHP){
        Vector2 health = new Vector2(hp/MaxHP, healthBar.transform.localScale.y);
        healthBar.transform.localScale = health;
        showHealthBar = true;
        if(coroutine == null)
            coroutine = StartCoroutine(ShowHealthBar());
    }

    IEnumerator ShowHealthBar()
    {
        while(showHealthBar){
            showHealthBar = false;
            healthBar.SetActive(true);
            Debug.Log("ready for sleep");
            yield return new WaitForSecondsRealtime(HPDisplayTime);
            Debug.Log("awake");
        }
            healthBar.SetActive(false);
            coroutine = null;
    }
}
