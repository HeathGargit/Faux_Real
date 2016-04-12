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

public class LevelManager : MonoBehaviour {
    
    public GameObject m_MainMenu, m_LevelSelect, m_CreditsMenu;
    GameObject[] m_Menus;
    
    private void Awake()
    {
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

    public void MenuSelect(int toMenu)
    {
        m_Menus[0].SetActive(false);
        m_Menus[1].SetActive(false);
        m_Menus[2].SetActive(false);
        m_Menus[toMenu].SetActive(true);
    }
    //this functions changes to/from a submenu
    public void LoadLevelSelect()
    {
        m_MainMenu.SetActive(false);
        m_CreditsMenu.SetActive(false);
        m_LevelSelect.SetActive(true);
    }

    public void LoadMainMenu()
    {
        m_MainMenu.SetActive(true);
        m_CreditsMenu.SetActive(false);
        m_LevelSelect.SetActive(false);
    }
}
