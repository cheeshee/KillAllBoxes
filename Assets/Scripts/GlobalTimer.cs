using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{

    [Header("Timer")]
    public float timer = 120; 

    void FixedUpdate(){

        timer -= Time.deltaTime;

        if(timer == 0){

            OutOfTime();

        }

    }

    protected virtual void OutOfTime(){

        Debug.Log("You're out of time!");
        //Lose Screen

    }

}
