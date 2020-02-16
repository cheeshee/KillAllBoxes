using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOrderController : MonoBehaviour
{
    private float timer = 0.0f;
    private float alarm = 200.0f;
    private float seconds = 0.5f;


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

        foreach (BoxController order in orders)
        {
            foreach (string key in order.fields)
            {
                if (order.attributes[key] != currentBox.attributes[key]) 
                {

                    Debug.Log("Incorrect!");
                    //Lose the game
                    break;
                
                }
                else if(order.attributes[key] == currentBox.attributes[key]){
                
                    Debug.Log("Correct!");
                    //Play a sound
                    break;
                
                }
            }
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
        GameObject currentBox = ObjectPooler.Instance.SpawnFromPool(Pool.NORMAL_BOX, transform.position, Quaternion.identity);
        BoxController order = currentBox.GetComponent<BoxController>();
        currentBox.SetActive(false);
        order.OnObjectSpawn();
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
        Add(order);
    }

    private void Update()
    {
        if (timer >= alarm)
        {
            timer = 0.0f;
            GenerateOrder();
        }
        else {
            //Debug.Log("timer = " +timer);
            timer += seconds;
        }
    }

}
