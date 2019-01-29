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
    private float levelScore=0f;//điểm từng màn được cộng vào đây
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
        curentScore += pointBlockdestroy;
        scoreTextChange();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    //2 hàm dưới đây để lưu điểm khi chết 
    public void AddScoreLevels()
    {
        levelScore=curentScore;
    }
    public void GetScoreLevels()
    {
        curentScore = levelScore;
        scoreTextChange();
    }



    private void scoreTextChange()
    {
        scoreText.text = curentScore.ToString();
    }
}
