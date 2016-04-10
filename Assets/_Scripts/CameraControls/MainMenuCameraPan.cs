/*---------------------------------------------------------
File Name: MainMenuCameraPan.cs
Purpose: Slowly rotate the main menu's camera to make it look cool and futuristicky
Author: Heath Parkes (gargit@gargit.net)
Modified: 20/3/2016
-----------------------------------------------------------
Copyright 2016 AIE/HP
---------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class MainMenuCameraPan : MonoBehaviour {

    //initialising the camera rotation speed.
    private float m_RotationSpeed = 0.0016f;

    //camera rotation is done in the fixedupdate to smooth it's pan. If it was done in normal update the pan speed would change depending on system performance.
    private void FixedUpdate()
    {
        transform.Rotate(0, m_RotationSpeed, 0);
    }
}
