using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    [SerializeField] private GameObject boxInst;

    [Header("Boolean")]
    [SerializeField] private bool onLadder;
    [SerializeField] private bool grabLadder;
    public bool inGrabRange;
    public bool holding;

    [Header("2DVec")]
    protected Vector2 move;

    [Header("Values")]
    [SerializeField]
    protected float jumpTakeOffSpeed;
    [SerializeField]
    protected int playerNumber = 1;
    [SerializeField]
    protected float maxSpeed = 1.6f;
    [SerializeField]
    private float ladderSpeed = 3;
    protected override void Start()
    {
        base.Start();
        onLadder = false;
        grabLadder = false;
    }



    protected override void FixedUpdate(){

        base.FixedUpdate();
        if (InputManager.GetHorizontal(playerNumber) < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (InputManager.GetHorizontal(playerNumber) > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        
        if (InputManager.IsShipping(playerNumber)) {
            pickUpBox();
        }

    }

    protected override void ComputeVelocity()
    {
        move = Vector2.zero;
        move.x = InputManager.GetHorizontal(playerNumber);




        if (onLadder && InputManager.GetVertical(playerNumber) != 0) 
        {
            grabLadder = true;
        }
        else if (!onLadder){
            grabLadder = false;
            gravityModifier = initialGravityModifier;
        }

        if (grabLadder)
        {

            Debug.Log(velocity.y);
            velocity.y = InputManager.GetVertical(playerNumber) * ladderSpeed;
            //isGrounded = true;
            gravityModifier = 0;
        }

        targetVelocity = move * maxSpeed;
    }

    protected private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == Tags.LADDER)
        {
            onLadder = true;
        } 
        else if (collision.tag == Tags.BOX)
        {
            Debug.Log("colliding trigger");
            boxInst = collision.gameObject;
            Debug.Log(boxInst);
            // grabBox = true;
        }
    }

    protected private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == Tags.BOX)
        {
            Debug.Log("colliding");
            boxInst = collision.collider.gameObject;
            Debug.Log(boxInst);
            inGrabRange = true;
        }
    }

    // protected private void OnCollisionExit2D(Collision2D collision) {
    //     if(collision.collider.tag == Tags.BOX && inGrabRange)
    //     {
    //         Debug.Log("Leaving collision");
    //         inGrabRange = false;
    //         boxInst = null;
    //     }
    // }

    protected private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Tags.LADDER)
        {
            onLadder = false;
        }
        // else if(collision.tag == Tags.BOX)
        // {
            
        //     grabBox = false;
        // }

    }

    private void pickUpBox() {

            if (holding)
            {
                holding = false;
                inGrabRange = false;
                boxInst.transform.parent = null;
                boxInst.GetComponent<Rigidbody2D>().simulated = true;
            }
            else if(inGrabRange)
            {
                holding = true;
                boxInst.transform.parent = gameObject.transform;
                boxInst.GetComponent<Rigidbody2D>().simulated = false;
            }
        
    }
    
}