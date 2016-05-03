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

    public Text m_UILevelText;
    
    // Use this for initialization
	void Start ()
    {
        string levelName = SceneManager.GetActiveScene().name;
        levelName = levelName.Replace("_", " ");
        m_UILevelText.text = levelName;
	}
	
	/*// Update is called once per frame
	void Update () {
	
	}*/
}
