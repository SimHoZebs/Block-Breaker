using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1;
    [SerializeField] private bool isStuck;
    [SerializeField] private float ballDistanceToPaddleWhenStuck;
    [SerializeField] private float xVelocity;
    [SerializeField] private float yVelocity;
    private Vector2 ballPos;
    private Vector2 ballVelocity;

    // Start is called before the first frame update
    void Start()
    {
        ballPos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y + ballDistanceToPaddleWhenStuck);
        ballVelocity = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update(){

        if (isStuck){
            LockPosition();
        }

        if (Input.GetMouseButtonDown(0)){
            LaunchOnClick();
        }
    }

    void LaunchOnClick(){

        if (isStuck){
        isStuck = false;
        GetComponent<Rigidbody2D>().velocity = ballVelocity;
        }
    }

    void LockPosition(){

        ballPos.x = paddle1.transform.position.x;
        transform.position = ballPos;
    }
}
