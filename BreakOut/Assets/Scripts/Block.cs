using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //hiệu ứng nổ
    [SerializeField] GameObject ImpactVFX;

    private Level level;
    private void Start()
    {
        CountBreaksBlock();
    }

    private void CountBreaksBlock()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Break")//Đếm số block tạo ra 
        {
            level.CountBlock(); //vì  mỗi có một block thì sẽ thực thi đoạn code này
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Break")
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        PlaySoundDestroy();
        Destroy(gameObject);
        level.DestroyBlock();
        ExplosionVFX();
    }

    private void PlaySoundDestroy()
    {
        FindObjectOfType<GameSeesion>().AddtoScore();//thêm điểm
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void ExplosionVFX()
    {
        GameObject I_explosion = Instantiate(ImpactVFX, transform.position, transform.rotation);
        Destroy(I_explosion, 1f);
    }

}
