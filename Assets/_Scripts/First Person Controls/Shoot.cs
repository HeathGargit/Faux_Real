/*---------------------------------------------------------
File Name: Shoot.cs
Purpose: What happens when you "shoot"
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 30/4/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System;

public class Shoot : MonoBehaviour {

    private string m_currentGun;
    public float m_ShoveSpeed;

    void Start()
    {
        m_currentGun = "Bubble";
    }

	void Update ()
    {
        //check if the "shoot" button is pushed.
	    if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            MainShoot();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            AltShoot();
        }
	}

    private void AltShoot()
    {
        Transform playerCam = Camera.main.transform;
        RaycastHit hitObject;
        Physics.Raycast(playerCam.position, playerCam.forward, out hitObject, 500f);
        if (hitObject.collider.tag == "Box")
        {
            if (m_currentGun == "Bubble")
            {
                hitObject.collider.gameObject.GetComponent<BlockMovement>().SetFloatDown();
            }
            if (m_currentGun == "PushPull")
            {
                hitObject.collider.gameObject.GetComponent<Rigidbody>().AddForce(hitObject.normal);
                Debug.Log(hitObject.normal);
            }
        }
    }

    private void MainShoot()
    {
        //this code shoots a ray towards where the camera/player is looking and does something if it hits the box
        Transform playerCam = Camera.main.transform;
        RaycastHit hitObject;
        Physics.Raycast(playerCam.position, playerCam.forward, out hitObject, 500f);
        if (hitObject.collider.tag == "Box")
        {
            hitObject.collider.gameObject.GetComponent<BlockMovement>().SetFloatUp();
        }
    }
}
