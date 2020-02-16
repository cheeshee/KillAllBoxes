using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileBoxController : BoxController
{
    public override void OnObjectSpawn()
    {
        base.OnObjectSpawn();
        isHeavy = true;
    }

    public override bool isBoxFragile()
    {
        return true;
    }
}
