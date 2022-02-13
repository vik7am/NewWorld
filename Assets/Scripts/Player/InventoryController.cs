using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    int arrow = 5;
    int metalShards = 1;
    int ridgeWood = 2;
    [SerializeField]AudioClip ridgeWoodClip;
    [SerializeField]AudioClip metalShardClip;
    [SerializeField]AudioClip medicinePlantClip;
    [SerializeField]AudioClip arrowClip;
    PlayerAudio playerAudio;
    AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        playerAudio = FindObjectOfType<PlayerAudio>();
    }

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
        playerAudio.PlayArrowCrafting();
        //audioSource.PlayOneShot(arrowClip, 1f);
        arrow += value;
    }

    public void AddMetalShards(int value){
        playerAudio.PlayMetalShard();
        //audioSource.PlayOneShot(metalShardClip, 1f);
        metalShards += value;
    }

    public void AddRidgeWoods(int value){
        playerAudio.PlayRidgeWood();
        //audioSource.PlayOneShot(ridgeWoodClip, 1f);
        ridgeWood += value;
    }

    public void PlayMedicinePlantClip(){
        playerAudio.PlayMedicinalPlant();
        //audioSource.PlayOneShot(medicinePlantClip, 1f);
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
