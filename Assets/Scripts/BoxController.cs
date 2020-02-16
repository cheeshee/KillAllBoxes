using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : PhysicsObject
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
    
    protected override void Start(){

        OnObjectSpawn();

        pattern = GetComponentsInChildren<SpriteRenderer>();

    }

    protected virtual void OnCollisionEnter2D(Collision2D col){

        Debug.Log("Box Entered Collision");

        string spriteApply = col.gameObject.name;

        if(col.collider.tag == Tags.STICKER){

            attributes["sticker"] = true;
            Update_Attributes(spriteApply);
            Change_Pattern(1, true, spriteApply);

        }
        if(col.collider.tag == Tags.WRAPPING){

            attributes["wrapping"] = true;
            Update_Attributes(spriteApply);
            Change_Pattern(2, false, spriteApply);

        }

    }

    protected virtual void Change_Pattern(int index, bool sticker, string spriteApply){

        pattern[index].sprite = GameObject.Find("SpriteContainer").GetComponent<BoxSpriteModifiers>().Apply_Sprite(sticker, spriteApply);
        pattern[index].enabled = true;

    } 

    void Update_Attributes(string spriteApply){

        Debug.Log("###Updating Attribute###");
        Debug.Log(spriteApply);

        List<string> keys = new List<string>(attributes.Keys);

        foreach(string key in keys){

            attributes[key] = false;

            if(key == spriteApply){

                attributes[key] = true;

            }

        }

    }

}
