using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController :  MonoBehaviour, IPooledObject
{
    public Dictionary<string, bool> attributes;
    public string[] fields = { "fragile", "heavy", "bubble", "wrapping" };
   
    // Start is called before the first frame update

    // Update is called once per frame
    
    protected virtual void Update()
    {

    }

    public virtual void OnObjectSpawn()
    {
        attributes = new Dictionary<string, bool>();
        foreach (string attribute in fields)
        {
            attributes.Add(attribute, false);
        }
    }
    /*
    void FixedUpdate(){

        Change_Active();

    }

    void Change_Active(){

        foreach(SpriteRenderer in pattern){

            if(attribute(pattern.gameObject.name) == false){

                pattern.enabled(false);

            }
            else if{

                pattern.enabled(true);

            }

        }

    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.tag == Tag.BUBBLE){

            attribute("bubble", true);

        }
        if(col.tag == Tag.WRAPPING){

            attribute("wrapping", true);

        }

    }

    void OnCOllisionExit2D(Collision2D col){
        
        if(col.tag == Tag.BUBBLE){

            attribute("bubble", false);

        }
        if(col.tag == Tag.WRAPPING){

            attribute("wrapping", false);

        }


    }
    */

}
