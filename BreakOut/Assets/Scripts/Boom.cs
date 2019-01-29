using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private bool isCollider = false;
    private CircleCollider2D BoomCollider;
    [SerializeField] int speedIncrease;

    private void Start()
    {
        BoomCollider = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isCollider)
        {
            if(BoomCollider.radius<2f)
            {
                BoomCollider.radius += speedIncrease * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollider = true;
    }
}
