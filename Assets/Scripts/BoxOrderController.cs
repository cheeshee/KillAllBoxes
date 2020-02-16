using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOrderController : MonoBehaviour
{
    public List<BoxController> orders = new List<BoxController>();
    // Start is called before the first frame update

    #region Singleton
    public static BoxOrderController instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one order form, not good.");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public void CheckBox(BoxController currentBox)
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
            Remove(checkedOrder);
            // play sound
        } else
        {
            // Penalty for incorrect box
        }
    }

    private void Remove (BoxController box )
    {
        orders.Remove(box);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void Add (BoxController box)
    {
        if (orders.Count < 8)
        {
            orders.Add(box);
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        } else
        {
            Debug.Log("Too many objects");
        }
        
    }

    void GenerateOrder()
    {
        BoxController order = new BoxController();

        int status = Random.Range(0, 4);
        int type = Random.Range(0, 3);
        int bubbleRNG = Random.Range(0, 2);
        if (status != 3)
        {
            order.attributes[order.fields[status]] = true;
        }
        if (bubbleRNG == 0)
        {
            order.attributes[order.fields[3]] = true;
        }
        switch (type)
        {
            case 1:
                order.isHeavy = true;
                break;
            case 2:
                order.isFragile = true;
                break;
            default:
                break;
        }
        orders.Add(order);
    }
}
