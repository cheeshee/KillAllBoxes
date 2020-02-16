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
    /*
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
            Change_Pattern(1, Resources.Load<Sprite>("./Sprites/" + col.gameObject.GetComponent<FloorController>().apply), Texture2D);
            Debug.Log("Changing Sticker to: " + "Sprites/" + col.gameObject.GetComponent<FloorController>().apply);

        }
        if(col.collider.tag == Tags.WRAPPING){

            attributes["wrapping"] = true;
            Change_Pattern(2, Resources.Load<Sprite>("Sprites/" + col.gameObject.GetComponent<FloorController>().apply), Sprite);
            Debug.Log("Changing Wrapper");

        }

    }

    void Change_Pattern(int index, Sprite apply){

        Debug.Log("Changing Sprite To: " + apply);
        pattern[index].sprite = apply;
        pattern[index].gameObject.transform.position.z.Equals(-1);
        pattern[index].enabled = true;

    } */

}
