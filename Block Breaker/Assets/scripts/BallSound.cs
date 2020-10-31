using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] paddleHitSound;
    [SerializeField] private AudioClip[] glassPaneHitSound;
    [SerializeField] public AudioSource audioSource;
    private string collidedObject;

    private void Start() {

        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        collidedObject = other.gameObject.name;

        if (collidedObject.Contains("glass pane")){
            audioSource.PlayOneShot(glassPaneHitSound[Random.Range(0, glassPaneHitSound.Length)]);
        }
        else if (collidedObject == "Paddle"){
            audioSource.PlayOneShot(paddleHitSound[Random.Range(0, paddleHitSound.Length)]);
        }
    }

}
