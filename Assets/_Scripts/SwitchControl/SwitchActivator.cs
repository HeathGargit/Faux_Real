/*---------------------------------------------------------
File Name: SwitchActivator.cs
Purpose: Tells the switch what to do when stuff happens.
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 30/4/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class SwitchActivator : MonoBehaviour {

    //used to hold a reference to the level change teleporter
    GameObject m_Teleporter;

	void Start ()
    {
        //find the level change teleporter and then de-activate it. It has to be active in the scene to be found on start.
        m_Teleporter = GameObject.FindGameObjectWithTag("LevelTeleporter");
        m_Teleporter.SetActive(false);
	}

    private void OnCollisionEnter(Collision collisionedObject)
    {
        //if the object that hit the switch was the box, then activate the level change teleporter!
        if (collisionedObject.gameObject.tag == "Box")
        {
            m_Teleporter.SetActive(true);
        }
    }
}
