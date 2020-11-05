using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int pointsPerBlockDestroyed = 10;
    [SerializeField] private Text textField;
    [SerializeField] private string currentScoreDisplayText = "SCORE: ";
    [SerializeField] private int startingScore = 0;
    private static int currentScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = startingScore;
    }

    // Update is called once per frame
    public void AddBlockDestroyedPoints(){
        currentScore += pointsPerBlockDestroyed;
    }
    void Update()
    {
        textField.text = currentScoreDisplayText + currentScore.ToString();
    }
}
