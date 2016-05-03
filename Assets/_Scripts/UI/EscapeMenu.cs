/*---------------------------------------------------------
File Name: EscapeMenu.cs
Purpose: Shows the in-game menu when escape is pushed.
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 3/5/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;

public class EscapeMenu : MonoBehaviour {

    //variables for the different UI screens. reference to the player to disable the mouse look when in menu.
    public GameObject m_InGameUI, m_EscapeMenu, m_Player;

    //references to some player components to disable when in menus. Not, cant disable the player gameObject because it has the camera on it.
    private Mouse_Look m_MouseLook;
    private MovementController m_MoveController;

    //keeps track of if the game is in a menu or not.
    private bool m_isInGame = true;

	//Initialization
	void Start ()
    {
        //setting the in game gui on and the escape menu off
        m_InGameUI.SetActive(true);
        m_EscapeMenu.SetActive(false);
        //hiding the cursor and locking it so you cant accidentally click outside the window.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //getting compnent references
        m_MouseLook = m_Player.GetComponent<Mouse_Look>();
        m_MoveController = m_Player.GetComponent<MovementController>();
	}
	
	// Update is called once per frame
	void Update () {
        //if the escape key is pushed, move between the gui and the escape menu.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeStates();
        }
	}
    
    //function to change between the normal GUI with the crosshair and the escape menu.
    private void ChangeStates()
    {
        //if in the game, show the escape menu
        if (m_isInGame)
        {
            m_InGameUI.SetActive(false);
            m_EscapeMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            m_MouseLook.enabled = false;
            m_MoveController.enabled = false;
            m_isInGame = false;
        }
        else //else show the in game gui, because you were in the escape menu
        {
            m_InGameUI.SetActive(true);
            m_EscapeMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            m_MouseLook.enabled = true;
            m_MoveController.enabled = true;
            m_isInGame = true;
        }
    }
}
