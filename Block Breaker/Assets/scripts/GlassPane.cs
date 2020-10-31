using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPane : MonoBehaviour
{
    GlassCounter glassCounter;
    private void Start() {
        glassCounter = FindObjectOfType<GlassCounter>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        glassCounter.reduceGlassPaneCount();
        Destroy(gameObject);
    }
}
