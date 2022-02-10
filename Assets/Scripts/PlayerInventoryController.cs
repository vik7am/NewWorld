using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    PlayerUIController player;
    int arrow = 5;
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
        
    

}
