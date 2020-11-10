using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPane : MonoBehaviour
{
    [SerializeField] private GlassPaneCounter glassPaneCounter;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject particleVFX;
    [SerializeField] private float particlesLifeTime;
    private GameObject particles;

    private void Start() {
        glassPaneCounter = FindObjectOfType<GlassPaneCounter>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        DestroyBlock();
    }

    private void DestroyBlock(){
        particles = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(particles, 0.2f);

        glassPaneCounter.reduceGlassPaneCount();
        scoreSystem.AddBlockDestroyedPoints();
        Destroy(gameObject);
    }
}
