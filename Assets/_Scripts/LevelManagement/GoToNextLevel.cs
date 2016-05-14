/*---------------------------------------------------------
File Name: LevelManager.cs
Purpose: To manage moving between the levels and the main menu, and quitting.
Author: Heath Parkes (gargit@gargit.net)
Modified: 12/4/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{

    public string m_NextLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LoadLevel(m_NextLevel);
        }
    }

    void LoadLevel(string targetLevel)
    {
        SceneManager.LoadScene(targetLevel);
    }
}