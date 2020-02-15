using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    


    [Header("Box Attributes")]
    [SerializeField] private Dictionary<string, bool> attributes;
    [SerializeField] private string[] fields = {"fragile", "heavy", "bubble", "wrapping"};
    [SerializeField] public SpriteRenderer[] pattern;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (string attribute in fields)
        {
            attributes.Add(attribute, false);
        }

        pattern = gameObject.GetComponentsInChildren<SpriteRenderer>();
        
    }

    

    void FixedUpdate(){

    }

}
