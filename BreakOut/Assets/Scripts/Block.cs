using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    private Level level;
    private void Start()
    {
        level = FindObjectOfType<Level>();//Đếm số block tạo ra 
        level.CountBlock();               //vì  mỗi có một block thì sẽ thực thi đoạn code này
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSeesion>().AddtoScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.DestroyBlock();
    }
}
