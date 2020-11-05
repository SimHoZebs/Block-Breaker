using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string lostSceneName;
    public void LoadNextScene(){
        int current_scene_index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene_index + 1);
    }
    public void RestartGame(){
        try{
        FindObjectOfType<ScoreSystem>().RestartGame();
        }
        catch{
            Debug.Log("ScoreSystem Object not found. Restarting without resetting the object's value.");
        }
        SceneManager.LoadScene(0);
    }

    public void LoadLostScene(){
        SceneManager.LoadScene(lostSceneName);
    }
}
