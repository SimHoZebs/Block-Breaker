using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [SerializeField] public int startingMax;
    [SerializeField] public int startingMin;
    [SerializeField] public Text guessText;
    int guess;
    int new_guess;
    int min;
    int max;
    // Start is called before the first frame update
    void Start()
    {
        min = startingMin;
        max = startingMax;
        guess = Random.Range(min, max + 1);
        new_guess = guess;
    }

    // Update is called once per frame
    void Update()
    {
        if (guess < new_guess){
            guess += 1;
        }
        if (guess > new_guess){
            guess -= 1;
        }
        guessText.text = guess.ToString();
    }

    public void Higher(){
        min = guess;
        new_guess = Random.Range(min + 1, max + 1);
    }

    public void Lower(){
        max = guess;
        new_guess = Random.Range(min + 1, max + 1);
    }
    
    public void QuitApp(){
        Application.Quit();
    }
}
