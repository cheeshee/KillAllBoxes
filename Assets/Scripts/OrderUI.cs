using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUI : MonoBehaviour
{
    // Start is called before the first frame update
    BoxOrderController boxorders;
    public Transform parentUI;
    OrderSlotController[] orderSlots;

    void Start()
    {
        boxorders = BoxOrderController.instance;
        boxorders.onItemChangedCallback += UpdateUI;

        orderSlots = parentUI.GetComponentsInChildren<OrderSlotController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI ()
    {
        for (int i = 0; i < orderSlots.Length; i++)
        {
            if (i < boxorders.orders.Count)
            {
                orderSlots[i].AddOrder(boxorders.orders[i]);
            } else
            {
                orderSlots[i].AddOrder(null);
            }
        }
    }
}
