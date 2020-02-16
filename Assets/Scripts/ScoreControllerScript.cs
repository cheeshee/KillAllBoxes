using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected int score = 0;

    #region Singleton
    public static ScoreControllerScript instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one order form, not good.");
            return;
        }
        instance = this;
    }
    #endregion

    public void addScore(int newScore)
    {
        score += newScore;
    }
    public void subtractScore(int penalty)
    {
        score -= penalty;
    }

    public int getScore()
    {
        return score;
    }
}
