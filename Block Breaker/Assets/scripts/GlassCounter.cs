using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCounter : MonoBehaviour
{
    [SerializeField] private int glassPaneCount; 
    [SerializeField] private int glassPaneCountToWin = 0;

    void Start()
    {
        glassPaneCount = FindObjectsOfType<GlassPane>().Length;
    }

    public void reduceGlassPaneCount(){
        glassPaneCount --;
    }
}