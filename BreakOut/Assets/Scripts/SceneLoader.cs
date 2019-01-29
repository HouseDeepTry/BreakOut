﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {

	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<GameSeesion>().AddScoreLevels();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSeesion>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetThisScene()
    {
        Application.LoadLevel(Application.loadedLevel);
        FindObjectOfType<GameSeesion>().GetScoreLevels();
    }
}
