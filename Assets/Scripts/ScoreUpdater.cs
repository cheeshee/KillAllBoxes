using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    ScoreControllerScript scorer;
    Text elementText;
    private void Start()
    {
        scorer = ScoreControllerScript.instance;
        elementText = GetComponent<Text>();
    }
    private void Update()
    {
        elementText.text = (scorer.getScore().ToString());
    }
}
