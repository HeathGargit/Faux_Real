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

    public GameObject m_InGameUI, m_EscapeMenu, m_Player;
    private Mouse_Look m_MouseLook;
    private bool m_isInGame = true;

	// Use this for initialization
	void Start () {
        m_InGameUI.SetActive(true);
        m_EscapeMenu.SetActive(false);
        Cursor.visible = false;
        m_MouseLook = m_Player.GetComponent<Mouse_Look>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeStates();
        }
	}
    
    private void ChangeStates()
    {
        if (m_isInGame)
        {
            m_InGameUI.SetActive(false);
            m_EscapeMenu.SetActive(true);
            Cursor.visible = true;
            m_MouseLook.enabled = false;
            m_isInGame = false;
        }
        else
        {
            m_InGameUI.SetActive(true);
            m_EscapeMenu.SetActive(false);
            Cursor.visible = false;
            m_MouseLook.enabled = true;
            m_isInGame = true;
        }
    }
}
