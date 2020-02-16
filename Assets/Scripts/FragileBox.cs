using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileBox : BoxController
{
    public override void OnObjectSpawn()
    {
        base.OnObjectSpawn();
        isHeavy = true;
    }
}
