using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    //set the tank movement speeds. Public so they can be changed in the editor all easy like.
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;

    //variables to hold stuff to do with making the player turn
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;

    private void Awake()
    {
        //get the reference to the tank this is attached to.
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //when the player is turned on, make sure it is not kinematic
        m_Rigidbody.isKinematic = false;

        //also reset the input values
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        // when the player is turned off, set it to kinematic so it stops moving
        m_Rigidbody.isKinematic = true;
    }

    private void Update()
    {
        //get the value of the inputs AKA find out if we turned/moved.
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //move and turn in the "physics" update
        Move();
        Turn();
    }

    private void Move()
    {
        
        
        //create a vector in the direction the player is facing with a magnatude
        // based on the input, speed and time between frames
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        //Apply this movement to the rigidbody's position
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);

    }

    private void Turn()
    {
        //Determine the number of degrees to be turned based on the input,
        // speed and time between frames
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        //make this into a rotation on the y axis
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // apply this rotation to the rigidbody's rotation
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}