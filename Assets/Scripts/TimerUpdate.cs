using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdate : MonoBehaviour
{
    public GlobalTimer currentTime;
    public Text elementText;

    private void Start()
    {
        currentTime = GameObject.Find("LevelTimer").GetComponent<GlobalTimer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elementText.text = currentTime.timer.ToString("0.0");
    }
}
