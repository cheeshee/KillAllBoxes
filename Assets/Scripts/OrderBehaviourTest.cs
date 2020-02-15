using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBehaviourTest : MonoBehaviour
{
    // Start is called before the first frame update

    void FixedUpdate()
    {
        if (Input.GetButtonDown("U"))
        {
            AddOrder();
        }
    }

    void AddOrder()
    {

    }
}
