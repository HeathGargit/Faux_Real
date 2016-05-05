/*---------------------------------------------------------
File Name: LevelManager.cs
Purpose: To manage moving between the levels and the main menu, and quitting.
Author: Heath Parkes (gargit@gargit.net)
Modified: 5/5/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    //setting objects up to be used to hold menus.
    public GameObject m_MainMenu, m_LevelSelect, m_CreditsMenu;
    GameObject[] m_Menus;
    
    private void Awake()
    {
        //adds the menus into an array
        m_Menus = new GameObject[] { m_MainMenu, m_LevelSelect, m_CreditsMenu };
    }

    //this function is called to change the level. It can be attached to buttons or called when the player finishes a level and is moving on to the next.
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    //this function quits the game. will only work in PC versions.
    public void QuitGame()
    {
        Application.Quit();
    }

    //function show a particular menu. Used to transition betwen menus.
    public void MenuSelect(int toMenu)
    {
        m_Menus[0].SetActive(false);
        m_Menus[1].SetActive(false);
        m_Menus[2].SetActive(false);
        m_Menus[toMenu].SetActive(true);
    }
}
