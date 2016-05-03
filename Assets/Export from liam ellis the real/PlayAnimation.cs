using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour
{

    public float maxWalkSpeed = 1000.0f;
    public float maxTurnSpeed = 10000.0f;
    public WrapMode animationWrap;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue; // The current value of the movement input
    private float m_TurnInputValue; // the current value of the turn input
    private Animator m_Animator;
    private float TurnSpeed;
    private float WalkSpeed;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        if (m_Animator == null)
        {
            print("null");
        }
        
    }

    private void OnEnable()
    {
        // when the tank is turned on, make sure it is not kinematic
        m_Rigidbody.isKinematic = false;
        // also reset the input values
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        // when the tank is turned off, set it to kinematic so it stops moving
        m_Rigidbody.isKinematic = true;
    }


    private void Move()
    {

            // Get the horizontal and vertical axis.
            WalkSpeed = Input.GetAxis("Vertical") * maxWalkSpeed;
            // Move translation along the object's z-axis.
            transform.Translate(0, 0, WalkSpeed * Time.deltaTime);

    }
  //  private void Turn()
  //  {

    //    TurnSpeed = Input.GetAxis("Horizontal") * maxTurnSpeed;
//
        // Rotate around our y-axis
   //     transform.Rotate(0, TurnSpeed * Time.deltaTime, 0);


 //   }

    private void Test()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            print("T was pressed");
            m_Animator.SetFloat("Forward Speed", 1);
            print(m_Animator.GetFloat("Forward Speed"));

        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            print("Y was pressed");
            m_Animator.SetFloat("Forward Speed", 0);
            print(m_Animator.GetFloat("Forward Speed"));

        }

    }




    void Start()
    {

    }

    private void FixedUpdate()
    {
    //    Turn();
        Move();
        Test();
    }

    void Update()
    { 
        
    }


}
