using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStates : MonoBehaviour
{
    [Range(0.1f, 3f)] [SerializeField] float m_speedGame;

    [SerializeField] float curentScore=0;
    [SerializeField] float pointBlockdestroy=10;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text=curentScore.ToString();
    }
    {
        /*Singleton Pattern
         * load GameStatus từ scene này qua scene mà ko bị destroy
        */
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
}
