using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Dictionary<string, bool> attributes;
    public string[] fields = {"fragile", "heavy", "bubble", "wrapping"};
    // Start is called before the first frame update
    void Start()
    {
        foreach (string attribute in fields)
        {
            attributes.Add(attribute, false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
