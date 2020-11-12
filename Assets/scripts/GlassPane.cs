using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPane : MonoBehaviour
{
    #region //particle system
    [SerializeField] private GameObject particleVFX;
    private float particleLifeTime = 0f;
    #endregion

    #region //Crack VFX
    [SerializeField] private GameObject[] crackSprites;
    #endregion

    #region //Break sound
    [SerializeField] private GameObject audioSource;
    [SerializeField] private AudioClip[] glassPaneHitSounds;
    [SerializeField] private AudioClip[] glassPaneBreakSounds;
    #endregion

    #region //glass pane colorHex, currHealth, totalHealth, crackSprite
    [System.Serializable] private struct GlassPaneTypes{
        public string colorHex;
        public int totalHealth;
        public int currHealth;
        public GameObject crackSprite;
        }

    [Tooltip("0 health is considered unbreakable.")]
    [SerializeField] private GlassPaneTypes[] glassPaneTypes = new GlassPaneTypes[6];
    [SerializeField] private GlassPaneTypes thisGlassPaneFields;
    #endregion

    #region //Initialzing objects for functions in other classes
    private GlassPaneCounter glassPaneCounter;
    private ScoreSystem scoreSystem;
    #endregion

    private void Start() {
        glassPaneCounter = FindObjectOfType<GlassPaneCounter>();
        scoreSystem = FindObjectOfType<ScoreSystem>();

        particleLifeTime = particleVFX.GetComponent<ParticleSystem>().main.duration;
        thisGlassPaneFields.colorHex = ColorUtility.ToHtmlStringRGB(gameObject.GetComponent<SpriteRenderer>().color);

        InitializeGlassPaneFields();
    }

    private void InitializeGlassPaneFields(){
        foreach (GlassPaneTypes glassPaneType in glassPaneTypes){
            if (thisGlassPaneFields.colorHex == glassPaneType.colorHex){
                thisGlassPaneFields.totalHealth = glassPaneType.totalHealth;
                thisGlassPaneFields.currHealth = thisGlassPaneFields.totalHealth;
                ShowCracks();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        AudioSystem.PlayRandomSFX(glassPaneHitSounds, audioSource);
        if (thisGlassPaneFields.currHealth == 1){
            DestroyBlock();
        }
        else if (thisGlassPaneFields.currHealth > 0){
            thisGlassPaneFields.currHealth--;
            ShowCracks();
        }
    }

    private void DestroyBlock(){
        AudioSystem.PlayRandomSFX(glassPaneBreakSounds, audioSource);
        PlayParticleVFX();
        glassPaneCounter.reduceGlassPaneCount();
        scoreSystem.AddBlockDestroyedPoints();
        Destroy(thisGlassPaneFields.crackSprite);
        Destroy(gameObject);
    }

    private void PlayParticleVFX(){
        var particles = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(particles, particleLifeTime);
    }

    private void ShowCracks(){
        var crackLevel = Convert.ToInt32((1- Convert.ToDouble(thisGlassPaneFields.currHealth)/Convert.ToDouble(thisGlassPaneFields.totalHealth)) * crackSprites.Length - 1);

        if (crackLevel >= 0){
            Destroy(thisGlassPaneFields.crackSprite);
            thisGlassPaneFields.crackSprite = Instantiate(crackSprites[crackLevel], transform.position, transform.rotation, gameObject.transform);
        }

    }

}
