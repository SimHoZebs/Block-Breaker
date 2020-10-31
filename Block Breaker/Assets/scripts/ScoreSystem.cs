using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int pointsPerBlockDestroyed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void AddBlockDestroyedPoints(){
        currentScore += pointsPerBlockDestroyed;
    }
    void Update()
    {
        
    }
}
