/*---------------------------------------------------------
File Name: EnableMouseMainMenu.cs
Purpose: Enable the mouse when you hit the main menu. Workaround for a bug where the mouse wasn't re-enabled after the last level.
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 3/5/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/
using UnityEngine;

public class EnableMouseMainMenu : MonoBehaviour {

	void Start ()
    {
        //Enables the mouse and unlocks it from the middle of the screen.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
