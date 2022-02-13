using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    AudioSource walkingAudio;
    AudioSource ridgeWoodAudio;
    AudioSource metalShardAudio;
    AudioSource medicinePlantAudio;
    AudioSource arrowCraftingAudio;
    
    void Awake()
    {
        walkingAudio = transform.GetChild(0).GetComponent<AudioSource>();
        ridgeWoodAudio = transform.GetChild(1).GetChild(0).GetComponent<AudioSource>();
        metalShardAudio = transform.GetChild(1).GetChild(1).GetComponent<AudioSource>();
        medicinePlantAudio = transform.GetChild(1).GetChild(2).GetComponent<AudioSource>();
        arrowCraftingAudio = transform.GetChild(1).GetChild(3).GetComponent<AudioSource>();
    }

    public void PlayWalingAudio(bool value){
        if(value)
            walkingAudio.Play();
        else
            walkingAudio.Stop();
    }

    public void PlayRidgeWood(){
        ridgeWoodAudio.Play();
    }

    public void PlayMetalShard(){
        metalShardAudio.Play();
    }

    public void PlayMedicinalPlant(){
        medicinePlantAudio.Play();
    }

    public void PlayArrowCrafting(){
        arrowCraftingAudio.Play();
    }

}
