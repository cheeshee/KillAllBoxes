using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalTimer : MonoBehaviour
{

    [Header("Timer")]
    public float timer = 120;
    public Text gameOver;
    public Text timeText;
    public Image panelBackground;


    private void Update()
    {
        if (Input.GetButtonDown("Exit"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


    void FixedUpdate(){

        timer -= Time.deltaTime;

        if(timer <= 0){

            OutOfTime();

        }
        if (timer <= -2)
        {
            LoadMenuScene();
        }

    }

    protected virtual void OutOfTime(){

        Debug.Log("You're out of time!");
        gameOver.gameObject.SetActive(true);
        timeText.gameObject.SetActive(false);
        panelBackground.gameObject.SetActive(true);


    }

    protected virtual void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
