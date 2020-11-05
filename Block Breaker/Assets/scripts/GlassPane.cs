using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPane : MonoBehaviour
{
    GlassPaneCounter glassPaneCounter;
    ScoreSystem scoreSystem;
    [SerializeField] private GameObject particleVFX;
    private void Start() {
        glassPaneCounter = FindObjectOfType<GlassPaneCounter>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        DestroyBlock();
    }

    private void DestroyBlock(){
        GameObject particles = Instantiate(particleVFX);
        glassPaneCounter.reduceGlassPaneCount();
        scoreSystem.AddBlockDestroyedPoints();
        Destroy(gameObject);
    }
}
