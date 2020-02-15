using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager{
    
    
    public static float GetHorizontal(int player)
    {
        float r = 0.0f;
        if(player == 1)
            r += Input.GetAxis("Key1_Horizontal");
        else if(player == 2)
            r += Input.GetAxis("Key2_Horizontal");

        return r;// Mathf.Clamp(r, -1.0f, 1.0f); //If both joystick and keyboard are being used, clamp between values
    }

    public static float GetVertical(int player)
    {
        float r = 0.0f;
        if(player == 1)
            r += Input.GetAxis("Key1_Vertical");
        else if(player == 2)
            r += Input.GetAxis("Key2_Vertical");
            
        return r; // Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainInput(int player)
    {
        return new Vector3(GetVertical(player), GetHorizontal(player), 0.0f );
    }

    public static bool IsInteracting(int player)
    {
        if(player == 1)
            return Input.GetButton("Action1");
        else if(player == 2)
            return Input.GetButton("Action2");           
        else    
            return false;
    }
    
    public static bool IsShipping(int player)
    {
        if (player == 1)
            return Input.GetButton("Ship1");
        else if (player == 2)
            return Input.GetButton("Ship2");
        else
            return false;
    }
    
    public static bool GetButtonUp(int player) {
        if (player == 1)
            return Input.GetButton("Up1");
        else if (player == 2)
            return Input.GetButton("Up2");
        else
            return false;
    }


}
