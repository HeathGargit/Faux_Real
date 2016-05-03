/*---------------------------------------------------------
File Name: GetLevelName.cs
Purpose: Gets the level name for the UI text element.
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 3/5/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetLevelName : MonoBehaviour {

    //exposed to the editor to link the text label
    public Text m_UILevelText;
    
    // Use this for initialization
	void Start ()
    {
        //get the level name from the current scene
        string levelName = SceneManager.GetActiveScene().name;

        //replace the underscores in the level names with spaces for human readability
        levelName = levelName.Replace("_", " ");

        // set the text label to show the level name
        m_UILevelText.text = levelName;
	}
}
