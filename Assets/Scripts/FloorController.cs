using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{

    /*
    [Header("Stickers")]
    public Dictionary<string, bool> stickers;

    [Header("Wrappers")]
    public Dictionary<string, bool> wrappers;
    */

    [Header("Sticker/Wrapper")]
    public string apply; 

    void Start(){

        //We can just name the floor either sticker1 or sticker2 etc then the sprite will be applied
        apply = gameObject.name;

    }

    /*
    void Awake(){

        for(int i = 0; i < 4; i++){

            stickers.Add("Sticker" + (i+1).ToString(), false);
            wrappers.Add("Wrapper" + (i+1).ToString(), false);

        }

        Set_Stick_Wrap();

    }   

    void Set_Stick_Wrap(){

        //Check if this floor is a sticker or a wrapper floor
        sticker = false;
        if(gameObject.tag == "Sticker"){

            sticker = true;

        }   

        if(sticker){

            foreach(KeyValuePair<string, bool> pick in stickers){

                if(pick.Key == gameObject.name){

                    stickers[pick.Key] = true;
                    apply = pick.Key;

                }

            }

        }
        else{

            foreach(KeyValuePair<string, bool> pick in wrappers){

                 if(pick.Key == gameObject.name){

                    wrappers[pick.Key] = true;
                    apply = pick.Key

                }

            }

        }

    }

    public SpriteRenderer Change_Sprite(SpriteRenderer spritechange){

        spritechange.sprite = apply;
        return 

    }
    */

}
