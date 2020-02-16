using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBoxController : BoxController
{

    public override void OnObjectSpawn()
    {
        base.OnObjectSpawn();
        isHeavy = true; 
    }

    public override bool isBoxHeavy()
    {
        return true;
    }

}
