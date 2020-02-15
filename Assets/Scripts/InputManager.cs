using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager{
    
    #region Player1Input
    public static float P1Horizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("Key1_Horizontal");
        return r;// Mathf.Clamp(r, -1.0f, 1.0f); //If both joystick and keyboard are being used, clamp between values
    }

    public static float P1Vertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("Key1_Vertical");
        return r; // Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 P1Input()
    {
        return new Vector3(P1Horizontal(), P1Horizontal(), 0.0f );
    }

    public static bool P1isInteracting()
    {
        return Input.GetButton("Action1");
    }
    #endregion Player1Input


    #region Player2Input

     public static float P2Horizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("Key2_Horizontal");
        return r;// Mathf.Clamp(r, -1.0f, 1.0f); //If both joystick and keyboard are being used, clamp between values
    }

    public static float P2Vertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("Key2_Vertical");
        return r;//Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 P2Input()
    {
        return new Vector3(P2Horizontal(), P2Horizontal(), 0.0f );
    }

    public static bool P2isInteracting()
    {
        return Input.GetButton("Action2");
    }

    #endregion Player2Input

}
