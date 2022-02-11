using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryController : MonoBehaviour
{
    PlayerUIController player;
    [SerializeField]GameObject mainInventory;
    [SerializeField]GameObject craftingMenu;
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

    public bool CanCraftArrow(){
        if(metalShards >=1 && ridgeWood >=2)
            return true;
        return false;
    }

    void OnCraft(){
        if(CanCraftArrow()){
            metalShards -= 1;
            ridgeWood -= 2;
            arrow += 10;
            UpdateCraftingMenu();
            updateUI();
        }
    }

    public void UpdateCraftingMenu()
    {
        craftingMenu.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = arrow.ToString();
        craftingMenu.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ridgeWood.ToString();
        craftingMenu.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = metalShards.ToString();
        
        
    }

    void updateUI(){
        player.UpdateAmmunationCounter(arrow);
    }

    public void UpdateInventory(){
        mainInventory.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = arrow.ToString();
        mainInventory.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ridgeWood.ToString();
        mainInventory.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = metalShards.ToString();
    }
        
    

}
