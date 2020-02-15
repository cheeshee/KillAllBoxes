using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOrderController : MonoBehaviour
{
    List<BoxController> orders = new List<BoxController>;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckBox(BoxController currentBox)
    {
        bool completed = true;
        BoxController checkedOrder = null;
        foreach (BoxController order in orders)
        {
            foreach (string key in order.fields)
            {
                if (order.attributes[key] != currentBox.attributes[key]) 
                {
                    completed = false;
                    break;
                }
            }
            if (completed)
            {
                checkedOrder = order;
                break;
            }
        }

        if (checkedOrder != null)
        {
            orders.Remove(checkedOrder);
            // play sound
        } else
        {
            // Penalty for incorrect box
        }
    }

    void GenerateOrder()
    {
        BoxController order = new BoxController();
        foreach (string key in order.fields)
        {
            int status = Random.Range(0, 2);
            if (status == 0)
            {
                order.attributes[key] = false;
            }
            else
            {
                order.attributes[key] = true;
            }
        }
        orders.Add(order);
    }
}
