using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    AudioSource walkingAudio;
    AudioSource hostileAudio;
    AudioSource arrowHitAudio;
    AudioSource laserAudio;
    
    void Awake()
    {
        walkingAudio = transform.GetChild(0).GetComponent<AudioSource>();
        hostileAudio = transform.GetChild(1).GetChild(0).GetComponent<AudioSource>();
        arrowHitAudio = transform.GetChild(2).GetComponent<AudioSource>();
        laserAudio = transform.GetChild(3).GetComponent<AudioSource>();
    }

    public void PlayWalingAudio(bool value){
        if(value)
            walkingAudio.Play();
        else
            walkingAudio.Stop();
    }

    public void PlayHostile(){
        hostileAudio.Play();
    }

    public void PlayArrowHit(){
        arrowHitAudio.Play();
    }

    public void PlayLaser(){
        laserAudio.Play();
    }
}
