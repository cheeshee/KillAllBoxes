using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{


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

    protected private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Tags.LADDER)
        {
            onLadder = false;
        }

    }


}