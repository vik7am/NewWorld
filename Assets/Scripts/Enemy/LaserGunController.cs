using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunController : MonoBehaviour
{
    [SerializeField]GameObject laser;
    [SerializeField]float laserSpeed = 5f;
    [SerializeField]float laserLife = 2f;
    Coroutine coroutine;
    bool fire;

    public void StartFire(){
        fire = true;
        if(coroutine == null){
             coroutine = StartCoroutine(FireLaser());
        }
    }

    public void StopFire(){
        fire = false;
    }

    IEnumerator FireLaser()
    {
        while(fire){
            yield return new WaitForSeconds(1);
            FireLaserBeam();
        }
        coroutine = null;
    }

    void FireLaserBeam()
    {
        Vector2 firePos = transform.position;
        transform.parent.GetChild(4).GetComponent<EnemyAudio>().PlayLaser();
        GameObject currentLaser = Instantiate(laser, firePos, transform.rotation);
        Rigidbody2D rb = currentLaser.GetComponent<Rigidbody2D>();
        if(rb != null)
            rb.velocity = transform.right * laserSpeed;
        Destroy(currentLaser, laserLife);
    }
}
