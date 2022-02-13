using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField]float HPDisplayTime = 3f;
    GameObject healthBar;
    SpriteRenderer statusBar;
    Coroutine coroutine;
    bool showHealthBar;
    bool hostile;

    private void Awake() {
        healthBar = transform.GetChild(1).gameObject;
        statusBar = transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start() {
        healthBar.SetActive(false);
        SetStatusBar("Normal");
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
            yield return new WaitForSeconds(HPDisplayTime);
        }
            healthBar.SetActive(false);
            coroutine = null;
    }

    public void SetStatusBar(string status){
        hostile = status == "Hostile";
        if(hostile)
            transform.GetChild(4).GetComponent<EnemyAudio>().PlayHostile();
            //transform.GetChild(2).GetComponent<AudioSource>().Play();
        if(status == "Normal")
            statusBar.color = new Color(0, 255, 0, 1);
        else if (status == "Idle")
            statusBar.color = new Color(255, 255, 0, 1);
        else if (status == "Hostile")
            statusBar.color = new Color(255, 0, 0, 1);

    }

    public bool IsHostile(){
        return hostile;
    }
}
