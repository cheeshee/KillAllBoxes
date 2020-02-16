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
        foreach (string key in currentBox.fields)
        {
            int status = Random.Range(0, 2);
            if (status == 0)
            {
                currentBox.attributes[key] = false;
            }
            else
            {
                currentBox.attributes[key] = true;
            }
        }
        ShowDictionary(currentBox);
        BoxOrderController.instance.Add(currentBox);
    }

    void ShowDictionary(BoxController box)
    {
        foreach(string key in box.attributes.Keys)
        {
            Debug.Log(key + "is " + box.attributes[key]);
        }
    }
}
