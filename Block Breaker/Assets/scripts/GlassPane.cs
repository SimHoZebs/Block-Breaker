using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPane : MonoBehaviour
{
    [SerializeField] private GameObject particleVFX;
    [SerializeField] private string unbreakableColorHex = "B700FF";
    private GlassPaneCounter glassPaneCounter;
    private ScoreSystem scoreSystem;
    private float particleLifeTime = 0f;
    private string glassPaneColorHex;

    private void Start() {
        glassPaneCounter = FindObjectOfType<GlassPaneCounter>();
        scoreSystem = FindObjectOfType<ScoreSystem>();

        particleLifeTime = particleVFX.GetComponent<ParticleSystem>().main.duration;
        glassPaneColorHex = ColorUtility.ToHtmlStringRGB(gameObject.GetComponent<SpriteRenderer>().color);

        if (glassPaneColorHex == unbreakableColorHex){
            gameObject.name = "Unbreakable";
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (gameObject.name != "Unbreakable"){
            DestroyBlock();
        }
    }

    private void DestroyBlock(){
        PlayParticleVFX();
        glassPaneCounter.reduceGlassPaneCount();
        scoreSystem.AddBlockDestroyedPoints();
        Destroy(gameObject);
    }

    private void PlayParticleVFX(){
        var particles = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(particles, particleLifeTime);
    }
}
