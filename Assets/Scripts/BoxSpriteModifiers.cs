using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpriteModifiers : MonoBehaviour
{

    [Header("StickerSprites")]
    [SerializeField] private Sprite[] stickers;

    [Header("Wrapper")]
    [SerializeField] private Sprite[] bubblewrap;

    public Sprite Apply_Sprite(bool sticker, string apply){

        //Debug.Log("Changing Sprite, is it a sticker? " + sticker.ToString());

        if(sticker){

            foreach(Sprite i in stickers){

                if(i.name == apply){
                    Debug.Log(i.ToString());
                    return i;
                }

            }

        }
        else{

            foreach(Sprite i in bubblewrap){

                if(i.name == apply){
                    return i;
                }

            }

        }

        return null;

    }
}
