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




}
