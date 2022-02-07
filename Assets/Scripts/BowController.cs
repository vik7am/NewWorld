using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowController : MonoBehaviour
{
    [SerializeField]GameObject arrow;
    GameObject currentArrow;

    private void Start() {
        
    }

    public void OnFire(InputValue value){
        currentArrow = Instantiate(arrow, transform.position, Quaternion.identity);
        StartCoroutine(DestroyArrow(currentArrow));
    }

    IEnumerator DestroyArrow(GameObject currentArrow)
    {
        yield return new WaitForSecondsRealtime(2);
        if(currentArrow != null)
            Destroy(currentArrow);
    }
}
