using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPaneCounter : MonoBehaviour
{
    [SerializeField] private int glassPaneCount = 0; 
    [SerializeField] private int glassPaneCountToWin;
    private SceneLoader sceneLoader;
    void Start()
    {
        CountGlassPanes();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void reduceGlassPaneCount(){

        glassPaneCount --;
        if(glassPaneCount <= glassPaneCountToWin){
            sceneLoader.LoadNextScene();
        }
    }
    
    public void CountGlassPanes(){
        var glassPaneArray = FindObjectsOfType<GlassPane>();

        foreach (GlassPane glassPane in glassPaneArray){
            if(glassPane.name.Contains("glass pane")){
                glassPaneCount ++;
            }
        }

    }
}