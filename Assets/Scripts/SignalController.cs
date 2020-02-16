using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GuiLargeSignals").GetComponentInChildren<Image>().color.a == 1){
            if(GameObject.Find("GuiLargeSignals").GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {

                GameObject.Find("GuiLargeSignals").GetComponentInChildren<Image>().color = new Color(255,255,255,0);
            }
        }
    }
}
