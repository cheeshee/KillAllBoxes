using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{



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
        targetVelocity = move * maxSpeed;
    }

   
}