using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBehaviourTest : MonoBehaviour
{
    // Start is called before the first frame update

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Action1"))
        {
            AddOrder();
        }
    }

    void AddOrder()

    {
        GameObject order = ObjectPooler.Instance.SpawnFromPool(Pool.NORMAL_BOX, transform.position, Quaternion.identity);
        BoxController currentBox = order.GetComponent<BoxController>();
        currentBox.OnObjectSpawn();
        int status = Random.Range(0, 4);
        int type = Random.Range(0, 3);
        int bubbleRNG = Random.Range(0, 2);
        if (status != 3)
        {
            currentBox.attributes[currentBox.fields[status]] = true;
        }
        if (bubbleRNG == 0)
        {
            currentBox.attributes[currentBox.fields[3]] = true;
        }
        switch (type)
        {
            case 1:
                currentBox.isHeavy = true;
                break;
            case 2:
                currentBox.isFragile = true;
                break;
            default:
                break;
        }
        Debug.Log("Here");
        BoxOrderController.instance.Add(currentBox);
    }

    void ShowDictionary(BoxController box)
    {
        foreach(string key in box.attributes.Keys)
        {
            //Debug.Log(key + "is " + box.attributes[key]);
        }
    }
}
