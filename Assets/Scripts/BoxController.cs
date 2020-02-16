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

         foreach(SpriteRenderer pat in pattern){

             if(pat.name != "PlaceHolder_Box"){

                 pat.enabled = false;

             }

         }

    }

    void OnCollisionEnter2D(Collision2D col){

        Debug.Log("Box Entered Collision");

        if(col.collider.tag == Tags.STICKER){

            attributes["sticker"] = true;
            Change_Pattern(1, true, col.gameObject.GetComponent<FloorController>().apply);

        }
        if(col.collider.tag == Tags.WRAPPING){

            attributes["wrapping"] = true;
            Change_Pattern(2, false, col.gameObject.GetComponent<FloorController>().apply);

        }

    }

    void Change_Pattern(int index, bool sticker, string apply){

        pattern[index].sprite = GameObject.Find("SpriteContainer").GetComponent<BoxSpriteModifiers>().Apply_Sprite(sticker, apply);
        pattern[index].enabled = true;

    }

}
