﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    SceneLoader sceneLoader;
    
    private void Start() {
        
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        sceneLoader.LoadLostScene();
    }

}
