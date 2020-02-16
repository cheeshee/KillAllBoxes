using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    private GameObject boxInst;
    private bool grabBox;

    private bool onLadder;
    private bool grabLadder;

    protected Vector2 move;

    [SerializeField]
    protected float jumpTakeOffSpeed;
    [SerializeField]
    protected int playerNumber = 1;
    [SerializeField]
    protected float maxSpeed = 1;




    protected override void FixedUpdate(){

        base.FixedUpdate();

    }

    protected override void ComputeVelocity()
    {
        move = Vector2.zero;
        move.x = InputManager.GetHorizontal(playerNumber);

        if (onLadder && InputManager.GetButtonUp(playerNumber))
        {
            grabLadder = true;
        }
        else if (!onLadder){
            grabLadder = false;
        }

        if (grabLadder)
        {
            move.y = InputManager.GetVertical(playerNumber);
        }

        targetVelocity = move * maxSpeed;
    }

    protected private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == Tags.LADDER)
        {
            onLadder = true;
        }
    }

    protected private void OnTriggerEnter2d(Collider2D collision) {
        if (collision.tag == Tags.BOX)
        {
            boxInst = collision.gameObject;
        }
    }

    protected private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Tags.LADDER)
        {
            onLadder = false;
        }
        if (collision.tag == Tags.BOX)
        {
            boxInst = null;
        }

    }

    private void pickUpBox() {
        if (InputManager.IsShipping(playerNumber)) {
            if (grabBox)
            {
                grabBox = true;
                boxInst.transform.parent = null;
            }
            else
            {
                grabBox = false;
                boxInst.transform.parent = gameObject.transform;
            }
        }
    }
    
}