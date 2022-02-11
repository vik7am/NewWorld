using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    int arrow = 5;
    int metalShards = 1;
    int ridgeWood = 2;
    [SerializeField]GameObject inventoryUI;
    [SerializeField]GameObject WeaponBar;

    public int getArrow(){
        return arrow;
    }

    public int GetMetalShards(){
        return metalShards;
    }

    public int GetRidgeWood(){
        return ridgeWood;
    }

    public void AddArrow(int value){
        arrow += value;
    }

    public void AddMetalShards(int value){
        metalShards += value;
    }

    public void AddRidgeWoods(int value){
        ridgeWood += value;
    }

    public bool RemoveArrow(int value){
        if(arrow >= value){
            arrow -= value;
            return true;
        }
        return false;
    }

    public bool RemoveMetalShards(int value){
        if(metalShards >= value){
            metalShards -= value;
            return true;
        }
        return false;
    }

    public bool RemoveRidgeWoods(int value){
        if(ridgeWood >= value){
            ridgeWood -= value;
            return true;
        }
        return false;
    }
}
