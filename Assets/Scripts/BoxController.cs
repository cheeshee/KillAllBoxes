using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    [Header("Box Attributes")]
    public Dictionary<string, bool> attributes;
    public string[] fields = {"blueSticker", "redSticker", "whiteSticker", 
                              "bubbleWrap"}; //test for push
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer[] pattern;


    public virtual void OnObjectSpawn()
    {
        attributes = new Dictionary<string, bool>();
        foreach (string attribute in fields)
        {
            attributes.Add(attribute, false);
            Debug.Log(attribute);
        }
    }
    
    void Start(){

        OnObjectSpawn();

        pattern = GetComponentsInChildren<SpriteRenderer>();

    }

    void OnCollisionEnter2D(Collision2D col){

        Debug.Log("Box Entered Collision");

        string apply = col.gameObject.GetComponent<FloorController>().apply;

        if(col.collider.tag == Tags.STICKER){

            attributes["sticker"] = true;
            Update_Attributes(apply);
            Change_Pattern(1, true, apply);

        }
        if(col.collider.tag == Tags.WRAPPING){

            attributes["wrapping"] = true;
            Update_Attributes(apply);
            Change_Pattern(2, false, apply);

        }

    }

    void Change_Pattern(int index, bool sticker, string apply){

        pattern[index].sprite = GameObject.Find("SpriteContainer").GetComponent<BoxSpriteModifiers>().Apply_Sprite(sticker, apply);
        pattern[index].enabled = true;

    } 

    void Update_Attributes(string apply){

        Debug.Log("###Updating Attribute###");
        Debug.Log(apply);

        List<string> keys = new List<string>(attributes.Keys);

        foreach(string key in keys){

            if(key == apply){

                attributes[key] = true;

            }
            else{

                attributes[key] = false;

            }

        }

    }

}
