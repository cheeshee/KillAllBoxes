using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button quitButton;

    void Start()
    {
        playButton.GetComponent<Button>().onClick.AddListener(PlayOnClick);
        quitButton.GetComponent<Button>().onClick.AddListener(QuitOnClick);
    }

    void PlayOnClick()
    {
        Debug.Log("play");
        SceneManager.LoadScene("LevelSampleScene");
    }

    void QuitOnClick()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}