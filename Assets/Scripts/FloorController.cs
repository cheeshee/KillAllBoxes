using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{

    [Header("Sticker/Wrapper")]
    public string apply; 


    void Start(){

        //We can just name the floor either sticker1 or sticker2 etc then the sprite will be applied
        apply = gameObject.name;

    }

}
