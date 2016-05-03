/*---------------------------------------------------------
File Name: MovementController.cs
Purpose: To move the player
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 30/4/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    //set the player movement speeds. Public so they can be changed in the editor all easy like.
    public float m_ForwardSpeed = 2f;
    public float m_StrafeSpeed = 2f;

    //variables to hold stuff to do with making the player move
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_StrafeInputValue;

    private void Awake()
    {
        //get the reference to the tank this is attached to.
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    /*private void OnEnable()
    {
        //when the player is turned on, make sure it is not kinematic
        m_Rigidbody.isKinematic = false;

        //also reset the input values
        m_MovementInputValue = 0f;
        m_StrafeInputValue = 0f;
    }

    private void OnDisable()
    {
        // when the player is turned off, set it to kinematic so it stops moving
        m_Rigidbody.isKinematic = true;
    }*/

    private void Update()
    {
        //get the value of the inputs AKA find out if we turned/moved.
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_StrafeInputValue = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //move in the "physics" update
        Move();
    }

    private void Move()
    {
        
        
        //create a vector with the direction the player is moving depending on keyboard input
        Vector3 forward = transform.forward * m_MovementInputValue * m_ForwardSpeed * Time.deltaTime;
        Vector3 strafe = transform.right * m_StrafeInputValue * m_StrafeSpeed * Time.deltaTime;

        Vector3 movement = forward + strafe;

        //Apply this movement to the rigidbody's position
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
}