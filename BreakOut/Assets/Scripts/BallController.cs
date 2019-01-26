using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallController : MonoBehaviour
{
    [SerializeField] PaddleController paddle1;
    [SerializeField] AudioClip[] ballClip;
    public float xPush = 2f;
    public float yPush = 15f;
    bool hasStart;
    Vector2 paddletoballVector;
    // có audio này để play audio 
    AudioSource myAudio;
    //
    void Start()
    {
        // khoảng cách từ quả bóng dến cái paddle
        paddletoballVector = transform.position - paddle1.transform.position;
        hasStart = false;
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStart==false)
        {
            DistanceBall();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStart = true;
        }
    }

    private void DistanceBall()
    {
        //giử quả bóng ở trên và luôn di chuyển theo paddle
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddletoballVector + paddlePos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip audio = ballClip[UnityEngine.Random.Range(0, ballClip.Length)];
        if (hasStart)
        {
            myAudio.PlayOneShot(audio);
        }
    }   
}
