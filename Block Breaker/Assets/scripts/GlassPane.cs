using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPane : MonoBehaviour
{
    //particle system
    [SerializeField] private GameObject particleVFX;
    private float particleLifeTime = 0f;

    //Break sound
    [SerializeField] private GameObject audioSource;
    [SerializeField] private AudioClip[] glassPaneBreakSound;

    //glass pane color differentiation
    [Tooltip("0 health is considered unbreakable.")]
    [SerializeField] private GlassPaneTypes[] glassPaneTypes = new GlassPaneTypes[6];
    private GlassPaneTypes glassPaneFields;
    [System.Serializable] private struct GlassPaneTypes{
        public string colorHex;
        public int health;
        private bool breakReady;
        }

    //Initialzing objects for functions in other classes
    private GlassPaneCounter glassPaneCounter;
    private ScoreSystem scoreSystem;

    private void Start() {
        glassPaneCounter = FindObjectOfType<GlassPaneCounter>();
        scoreSystem = FindObjectOfType<ScoreSystem>();

        particleLifeTime = particleVFX.GetComponent<ParticleSystem>().main.duration;
        glassPaneFields.colorHex = ColorUtility.ToHtmlStringRGB(gameObject.GetComponent<SpriteRenderer>().color);

        InitializeGlassPaneFields();
    }

    private void InitializeGlassPaneFields(){
        foreach (GlassPaneTypes glassPaneType in glassPaneTypes){
            if (glassPaneFields.colorHex == glassPaneType.colorHex){
                glassPaneFields.health = glassPaneType.health;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (glassPaneFields.health == 1){
            DestroyBlock();
        }
        else if (glassPaneFields.health > 0){
            glassPaneFields.health--;
        }
    }

    private void DestroyBlock(){
        PlayBreakSFX();
        PlayParticleVFX();
        glassPaneCounter.reduceGlassPaneCount();
        scoreSystem.AddBlockDestroyedPoints();
        Destroy(gameObject);
    }

    private void PlayParticleVFX(){
        var particles = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(particles, particleLifeTime);
    }

    private void PlayBreakSFX(){
        var chosenSound = glassPaneBreakSound[Random.Range(0, glassPaneBreakSound.Length)];
        var audioSourceLocation = audioSource.transform.localPosition;
        AudioSource.PlayClipAtPoint(chosenSound, audioSourceLocation);

        //This doesn't work because why??
        //var test = audioSource.GetComponent<AudioSource>();
        //test.PlayOneShot(chosenSound);
    }
}
