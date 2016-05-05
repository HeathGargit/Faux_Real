/*---------------------------------------------------------
File Name: Shoot.cs
Purpose: What happens when you "shoot"
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 5/5/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    //variable to hold the current gun in use.
    private string m_currentGun;

    //sets the speed that the gun pushes/pulls the box.
    private float m_ShoveSpeed = 10.0f;

    //used to set the gun name in the UI. will probably replace with a picture at some point.
    public Text m_UIGunText;

    void Start()
    {
        //start the level with the bubble gun. update the UI to show that - otherwise it wont show until you change guns.
        m_currentGun = "Bubble";
        m_UIGunText.text = m_currentGun;
    }

	void Update ()
    {
        //check if the "shoot" button (left mouse button) is pushed.
	    if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            MainShoot();
        }
        //check if the "alt" shoot (right mouse button.
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            AltShoot();
        }
        //check if the switch gun button is pushed.
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapons();
        }
	}

    //This changes the gun that is being shot.
    private void ChangeWeapons()
    {
        //If the current gun is the bubble gun, change it to the pushpull gun.
        if (m_currentGun == "Bubble")
        {
            m_currentGun = "PushPull";
        }
        else //if it isn't the bubble gun, change it to that!
        {
            m_currentGun = "Bubble";
        }

        //Update the gui to show which gun is selected.
        m_UIGunText.text = m_currentGun;
    }

    //what happens when the right mouse button is pressed.
    private void AltShoot()
    {
        //A ray shoots out from the FPS camera. If it hits the box, something happens depending on which current gun is selected.
        Transform playerCam = Camera.main.transform;
        RaycastHit hitObject;
        Physics.Raycast(playerCam.position, playerCam.forward, out hitObject, 500f);
        if (hitObject.collider.tag == "Box") //if the gameobject that's hit is the box, 
        {
            if (m_currentGun == "Bubble") //then tell the box to float up if the bubble gun is active
            {
                hitObject.collider.gameObject.GetComponent<BlockMovement>().SetFloatDown();
            }
            if (m_currentGun == "PushPull") //or tell the box to move if the pushpull gun is currently active.
            {
                //pulls the box according to the "normal" of where the box is hit times the speed of the shove.
                Rigidbody blockBody = hitObject.collider.gameObject.GetComponent<Rigidbody>();
                blockBody.velocity = hitObject.normal * m_ShoveSpeed; //Yes, I looked up what a normal is. It's perpendicular to the point that was hit by the ray.
            }
        }
    }

    //what happens when the Left Mouse button is pushed.
    private void MainShoot()
    {
        //this code shoots a ray towards where the camera/player is looking and does something if it hits the box
        Transform playerCam = Camera.main.transform;
        RaycastHit hitObject;
        Physics.Raycast(playerCam.position, playerCam.forward, out hitObject, 500f);
        if (hitObject.collider.tag == "Box") //if the gameobject hit by the ray is the box.
        {
            if (m_currentGun == "Bubble") //do this if the current gun is bubble gun
            {
                hitObject.collider.gameObject.GetComponent<BlockMovement>().SetFloatUp();
            }
            if (m_currentGun == "PushPull") //or do this if current gun is pushpull
            {
                Rigidbody blockBody = hitObject.collider.gameObject.GetComponent<Rigidbody>();
                blockBody.velocity = hitObject.normal * m_ShoveSpeed * -1; //multiplying by pushes rather than pulls.
            }
        }
    }
}
