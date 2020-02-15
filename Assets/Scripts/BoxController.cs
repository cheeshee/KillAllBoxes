using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    [Header("Box Attributes")]
    [SerializeField] private Dictionary<string, bool> attributes;
    [SerializeField] private string[] fields = {"fragile", "heavy", "bubble", "wrapping"};
    [SerializeField] public transform[] pattern;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (string attribute in fields)
        {
            attributes.Add(attribute, false);
        }

        pattern = gameObject.GetComponentsInChildren<transform>();
        
    }

    void FixedUpdate(){

        Change_Active();

    }

    void Change_Active(){

    
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


}
