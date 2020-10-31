using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPane : MonoBehaviour
{
    GlassPaneCounter glassPaneCounter;
    ScoreSystem scoreSystem;
    private void Start() {
        glassPaneCounter = FindObjectOfType<GlassPaneCounter>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        glassPaneCounter.reduceGlassPaneCount();
        scoreSystem.AddBlockDestroyedPoints();
        Destroy(gameObject);
    }
}
