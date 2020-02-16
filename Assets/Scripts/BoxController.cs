using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    [Header("Box Attributes")]
    public Dictionary<string, bool> attributes;
    public string[] fields = {"fragile", "heavy", "sticker", "wrapping"};
    [SerializeField] private SpriteRenderer[] pattern;
    // Start is called before the first frame update

    public virtual void OnObjectSpawn()
    {
        attributes = new Dictionary<string, bool>();
        foreach (string attribute in fields)
        {
            attributes.Add(attribute, false);
        }
    }

    void Start(){

        attributes = new Dictionary<string, bool>();
        foreach (string attribute in fields)
        {
            attributes.Add(attribute, false);
        }

         pattern = GetComponentsInChildren<SpriteRenderer>();

    }

    void FixedUpdate(){

        Change_Active();

    }

    void Change_Active(){

        foreach(KeyValuePair<string, bool> pair in attributes){

            if(pair.Key == "bubble"){

                pattern[1].enabled = pair.Value;

            }
            else if(pair.Key == "wrapping"){

                pattern[2].enabled = pair.Value;

            }

        }

    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.collider.tag == Tags.STICKER){

            attributes["sticker"] = true;

        }
        if(col.collider.tag == Tags.WRAPPING){

            attributes["wrapping"] = true;

        }

    }

    void OnCOllisionExit2D(Collision2D col){
        
        if(col.collider.tag == Tags.STICKER){

            attributes["sticker"] = false;

        }
        if(col.collider.tag == Tags.WRAPPING){

            attributes["wrapping"] = false;
 
        }


    }


}
