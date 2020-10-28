using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float screenWidthInUnits = 16f;
    public bool canMove = true;
    private float xMinLimit;
    private float xMaxLimit;
    void Start()
    {
        xMinLimit = transform.localScale.x / 2;
        xMaxLimit = screenWidthInUnits - xMinLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            var xAxis = Mathf.Clamp(Input.mousePosition.x/Screen.width * screenWidthInUnits, xMinLimit, xMaxLimit);
        Vector2 paddlePos = new Vector2(xAxis, transform.position.y);
        transform.position = paddlePos;
        }
        else{

        }
    }
}
