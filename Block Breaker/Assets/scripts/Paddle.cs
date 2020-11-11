using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle: MonoBehaviour
{
    public float screenWidthInUnits = 16f;
    public bool canMove = true;
    private float xMinLimit;
    private float xMaxLimit;
    private Vector2 paddlePos;
    [SerializeField] private GameObject audioSource;
    [SerializeField] private AudioClip[] paddleHitSound;

    void Start()
    {
        xMinLimit = transform.localScale.x / 2;
        xMaxLimit = screenWidthInUnits - xMinLimit;
        paddlePos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            paddlePos.x = Mathf.Clamp(Input.mousePosition.x/Screen.width * screenWidthInUnits, xMinLimit, xMaxLimit);
            transform.position = paddlePos;
        }
        else{

        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
            var chosenSound = paddleHitSound[Random.Range(0, paddleHitSound.Length)];
            var audioSourcePosition = audioSource.transform.localPosition;

            AudioSource.PlayClipAtPoint(chosenSound, audioSourcePosition);
    }
}
