using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectablecontroller : MonoBehaviour
{
    [SerializeField]bool isridgeWood;
    [SerializeField]bool ismetalShard;
    [SerializeField]bool ismedicinePlant;

    private void Start() {
        if(ismetalShard)
            GetComponent<AudioSource>().Play();
    }

    public string GetItemText(){
        if(isridgeWood)
            return "E - Gather Ridge-wood";
        if(ismetalShard)
            return "E - Gather Metal Shard";
        if(ismedicinePlant)
            return "E - Gather Medicinal Plant";
        return "Nothing";
    }

    public int GetItemType()
    {
        if(isridgeWood)
            return 1;
        if(ismetalShard)
            return 2;
        if(ismedicinePlant)
            return 3;
        return 0;
    }
}
