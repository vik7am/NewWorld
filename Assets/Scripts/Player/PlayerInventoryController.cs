using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryController : MonoBehaviour
{
    PlayerUIController player;
    [SerializeField]GameObject mainInventory;
    int arrow = 5;
    int metalShards = 0;
    int ridgeWood = 0;

    void Start()
    {
        player = GetComponent<PlayerUIController>();
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddArrow(int value){
        arrow += value;
        updateUI();
    }

    public void AddMetalShards(int value){
        metalShards += value;
    }

    public void AddRidgeWoods(int value){
        ridgeWood += value;
    }

    public bool RemoveArrow(int value){
        if(arrow > 0){
            arrow -= value;
            updateUI();
            return true;
        }
        else
            return false;
    }

    void updateUI(){
        player.UpdateAmmunationCounter(arrow);
    }

    public void updateInventory(){
        mainInventory.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = arrow.ToString();
        mainInventory.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ridgeWood.ToString();
        mainInventory.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = metalShards.ToString();
    }
        
    

}
