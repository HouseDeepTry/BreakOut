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

    //Khi va chạm sẽ có những vận tốc khác nhau để tránh hiện tượng di chuyển ngang vĩnh viễn
    [SerializeField] float randomFactor = 0.2f;
    Rigidbody2D myRigibody2D;
    void Start()
    {
        // khoảng cách từ quả bóng dến cái paddle
        paddletoballVector = transform.position - paddle1.transform.position;
        hasStart = false;
        myAudio = GetComponent<AudioSource>();
        myRigibody2D = GetComponent<Rigidbody2D>();

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
            myRigibody2D.velocity = new Vector2(xPush, yPush);
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
        Vector2 VecrandomFactor = new Vector2(Random.Range(0,randomFactor), Random.Range(0, randomFactor));
        if (hasStart)
        {
            AudioClip audio = ballClip[UnityEngine.Random.Range(0, ballClip.Length)];
            myAudio.PlayOneShot(audio);
            myRigibody2D.velocity += VecrandomFactor;
        }
    }   
}
