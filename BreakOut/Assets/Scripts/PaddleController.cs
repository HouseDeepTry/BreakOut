using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float screenwidthUnit = 16f;
    [SerializeField] float Xmax;
    [SerializeField] float Xmin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosUnit=(Input.mousePosition.x/Screen.width*screenwidthUnit);
        Vector2 paddlePos = new Vector2(Mathf.Clamp(mousePosUnit,Xmin,Xmax),transform.position.y);
        transform.position = paddlePos;
    }
}
