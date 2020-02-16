using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBox : BoxController
{

    public override void OnObjectSpawn()
    {
        base.OnObjectSpawn();
        isHeavy = true; 
    }



}
