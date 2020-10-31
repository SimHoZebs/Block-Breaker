using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPane : MonoBehaviour
{
    GlassPaneCounter glassPaneCounter;
    private void Start() {
        glassPaneCounter = FindObjectOfType<GlassPaneCounter>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        glassPaneCounter.reduceGlassPaneCount();
        Destroy(gameObject);
    }
}
