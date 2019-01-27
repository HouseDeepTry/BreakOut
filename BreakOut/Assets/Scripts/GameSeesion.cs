using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSeesion : MonoBehaviour
{
    [Range(0.1f, 3f)] [SerializeField] float m_speedGame;

    [SerializeField] float curentScore=0;
    [SerializeField] float pointBlockdestroy=10;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text=curentScore.ToString();
    }
    private void Awake()
    {
        /*Singleton Pattern
         * load GameStatus từ scene này qua scene mà ko bị destroy
        */
        int GameStatusCount = FindObjectsOfType<GameSeesion>().Length;
        if(GameStatusCount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = m_speedGame;
    }
    public void AddtoScore()
    {
        curentScore+=pointBlockdestroy;
        scoreText.text=curentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
