using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{

    InventoryController inventory;

    void Awake()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    private void Start() {
        UpdateUI();
    }

    public void UpdateUI(){
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = inventory.getArrow().ToString();
        transform.GetChild(1).GetChild(0).GetComponent<Text>().text = inventory.GetRidgeWood().ToString();
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = inventory.GetMetalShards().ToString();
    }
}
