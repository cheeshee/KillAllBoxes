using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{



    protected Vector2 move;

    [SerializeField]
    protected float jumpTakeOffSpeed;





    protected override void FixedUpdate(){

        base.FixedUpdate();

    }

    protected override void ComputeVelocity()
    {
        move = Vector2.zero;




    move.x = InputManager.MainHorizontal();

    if (InputManager.GetButtonDown("Jump") && isGrounded) //checks if jump button is pressed while grounded
    {
        velocity.y = jumpTakeOffSpeed;
    }

    else if (Input.GetButtonUp("Jump")) // reduces velocity when user lets go of jump button
    {
        if (velocity.y > 0)
            velocity.y = velocity.y * 0.5f;
    }

    // detect dash






    targetVelocity = move * maxSpeed;

   

}