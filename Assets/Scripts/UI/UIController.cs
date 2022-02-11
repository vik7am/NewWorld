using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    GameObject player;
    bool gamePaused;
    int activeUI;
    InventoryUIController inventoryUI;
    CraftingUIController craftingUI;

    private void Awake() {
        inventoryUI = FindObjectOfType<InventoryUIController>();
        craftingUI = FindObjectOfType<CraftingUIController>();
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
        SetActiveUI(0);
    }

    public void DisplayUI(int UI){
        SetActiveUI(UI);
        for(int i=0; i < 3; i++)
            if(i == UI)
                transform.GetChild(i).gameObject.SetActive(true);
            else
                transform.GetChild(i).gameObject.SetActive(false);
    }

    void OnInventory(InputValue value){
        
        if(getActiveUI() == 0){   
            PauseGame();
            DisplayInventoryUI();
        }
        else if(getActiveUI() == 1){
            ResumeGame();
            DisplayGameUI();
        }
        else if(getActiveUI() == 2){
            DisplayInventoryUI();
        }
    }

    void OnCrafting(InputValue value){
        if(getActiveUI() == 0){
            PauseGame();
            DisplayCraftingUI();
        }
        else if(getActiveUI() == 1){
            DisplayCraftingUI();
        }
        else if(getActiveUI() == 2){
            ResumeGame();
            DisplayGameUI();
        }
    }

    void PauseGame(){
        Time.timeScale = 0;
    }

    void ResumeGame(){
        Time.timeScale = 1;
    }

    public int getActiveUI(){
        return activeUI;
    }

    public void SetActiveUI(int value){
        activeUI = value;
    }

    public void DisplayGameUI(){
        DisplayUI(0);
    }

    public void DisplayInventoryUI(){
        DisplayUI(1);
        inventoryUI.UpdateUI();
    }

    public void DisplayCraftingUI(){
        DisplayUI(2);
        craftingUI.UpdateUI();
    }

}
