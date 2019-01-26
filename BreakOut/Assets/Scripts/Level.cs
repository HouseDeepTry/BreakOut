using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlock;
    private SceneLoader m_sceneloader;
    private void Start()
    {
        m_sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlock()
    {
        breakableBlock++;
    }
    public void DestroyBlock()
    {
        breakableBlock--;
        if (breakableBlock<=0)
        {
            m_sceneloader.LoadNextScene();
        }
    }
}
