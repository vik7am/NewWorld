using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    InventoryController inventory;

    private void Awake() {
        inventory = FindObjectOfType<InventoryController>();
    }

    void Start()
    {
        SetNewGameUI();
    }

    private void SetNewGameUI()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
    }

    public void PlayerVisibility(bool value){
        if(value){
            transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
        }
        else{
            transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
        }
    }

    public void UpdateHealthBar(float value){
        transform.GetChild(0).GetComponent<Slider>().value = value;
    }

    public void UpdateMedicineBar(float value){
        transform.GetChild(4).GetComponent<Slider>().value = value;
    }

    public void UpdateWeaponBar(){
        transform.GetChild(1).GetChild(2).GetComponent<Text>().text = inventory.getArrow().ToString();
    }

    public void DisplayWeaponBar(){
        transform.GetChild(1).gameObject.SetActive(true);
        UpdateWeaponBar();
    }

    public void DisplayCollectableBar(string text){
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = text;
    }

    public void HideWeaponBar(){
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void HideCollectableBar(){
        transform.GetChild(2).gameObject.SetActive(false);
    }
}
