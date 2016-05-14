/*---------------------------------------------------------
File Name: MovementController.cs
Purpose: To move the player
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 10/5/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;

public class MovementController : MonoBehaviour {

    //set the player movement speeds. Public so they can be changed in the editor all easy like.
    public float m_ForwardSpeed = 2.0f;
    public float m_StrafeSpeed = 2.0f;

    //variables to hold stuff to do with making the player move
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_StrafeInputValue;

    //this holds the animator component attached to the gameobject ("player")
    private Animator m_Animator;

    private void Awake()
    {
        //get the reference to the tank this is attached to.
        m_Rigidbody = GetComponent<Rigidbody>();
        //stops the rigidbody from rotating
        if (m_Rigidbody)
            m_Rigidbody.freezeRotation = true;
        //get the animator component.
        m_Animator = GetComponent<Animator>();
        if (m_Animator == null)
        {
            print("null");
        }
    }

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
        //if the player is moving backwards or forwards
        if (m_MovementInputValue >= 0.1 || m_MovementInputValue <= -0.1)
        {
            //then plays the animation by filling the requirements for play
            m_Animator.SetFloat("Speed", 1);
        }
        else
        {
            //else stop the animation from playing because we arent moving!
            m_Animator.SetFloat("Speed", 0);
        }

        //create a vector with the direction the player is moving depending on keyboard input
        Vector3 forward = transform.forward * m_MovementInputValue * m_ForwardSpeed * Time.deltaTime;
        Vector3 strafe = transform.right * m_StrafeInputValue * m_StrafeSpeed * Time.deltaTime;

        Vector3 movement = forward + strafe;

        

        //Apply this movement to the rigidbody's position
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
}