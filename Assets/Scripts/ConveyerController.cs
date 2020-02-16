using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerController : MonoBehaviour
{
    public GameObject spawner;
    public Transform endpoint;
    public float speed = 2f;
    // Start is called before the first frame update
    protected void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Should be moving");
        other.transform.position = Vector2.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
    }
}
