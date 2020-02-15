using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    protected override void FixedUpdate(){

        base.FixedUpdate();

    }

    protected override void ComputeVelocity()
    {
        move = Vector2.zero;


        if (isAttacking)
        {
            attackMovementDelegate?.Invoke();
        }
        else
        {

            move.x = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && isGrounded) //checks if jump button is pressed while grounded
            {
                velocity.y = jumpTakeOffSpeed;
            }

            else if (Input.GetButtonUp("Jump")) // reduces velocity when user lets go of jump button
            {
                if (velocity.y > 0)
                    velocity.y = velocity.y * 0.5f;
            }

            // detect dash

            if (Input.GetButtonDown("DashLeft")) //checks if "a" or left arrow button was pressed
            {

                float timesinceLastLeft = Time.time - lastLeftTime;

                if (timesinceLastLeft <= DOUBLE_PRESS_TIME)
                {
                    dashDirection = -1;
                    dashTime = startDashTime;//timer for dash
                    Debug.Log("dashTime:" + dashTime);
                    Debug.Log("double left");//delta tiime
                }
                //Double click
                else
                {
                    //Normal Click
                    lastLeftTime = Time.time;
                }


            }

            if (Input.GetButtonDown("DashRight")) //checks if "d" or right arrow button was pressed
            {

                float timesinceLastRight = Time.time - lastRightTime;

                if (timesinceLastRight <= DOUBLE_PRESS_TIME)
                {
                    dashDirection = 1;
                    dashTime = startDashTime;//timer for dash
                    Debug.Log("dashTime:" + dashTime);

                    Debug.Log("double right");//debug delta time
                }
                //double click
                else
                {
                    //Normal Click
                    lastRightTime = Time.time;
                }
            }

            if (dashTime > 0)
            {
                move.x = dashDirection * dashMultiplier;
                dashTime -= Time.deltaTime; //Decrease time counter
            }
        }


        targetVelocity = move * maxSpeed;

    }

}