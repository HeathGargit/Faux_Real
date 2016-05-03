/*---------------------------------------------------------
File Name: BlockMovement.cs
Purpose: To move the block when it is hit by the player's physics guns
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 30/4/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System;

public class BlockMovement : MonoBehaviour {

    //get the block's rigidbody
    Rigidbody m_Rigidbody;

    //says if the block is floating or not
    private bool m_isFloating = false;

	void Start ()
    {
        //Get the rigidbody to do stuff with.
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	/*void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_isFloating = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            m_isFloating = false;
        }
	}*/

    void FixedUpdate()
    {
        if (m_isFloating)
        {
            FloatUp();
        }
        else
        {
            FloatDown();
        }
    }

    //makes the box fall down.
    private void FloatDown()
    {
        m_Rigidbody.useGravity = true;
        //m_Rigidbody.AddForce(Vector3.up);
    }

    //makes the box float up.
    private void FloatUp()
    {
        m_Rigidbody.useGravity = false;
        m_Rigidbody.AddForce(Vector3.up);
    }

    public void SetFloatUp()
    {
        m_isFloating = true;
    }

    public void SetFloatDown()
    {
        m_isFloating = false;
    }
}
