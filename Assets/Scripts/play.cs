using UnityEngine;
using System.Collections;

public class play : MonoBehaviour {

    public float maxWalkSpeed = 10.0f;
    public float maxTurnSpeed = 100.0f;

    // Use this for initialization
    void Start () {

}
	
	// Update is called once per frame
	void Update () {

        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        var walkSpeed = Input.GetAxis("Vertical") * maxWalkSpeed;
        var turnSpeed = Input.GetAxis("Horizontal") * maxTurnSpeed;
        // Move translation along the object's z-axis
        transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        // Rotate around our y-axis
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        if (walkSpeed > 5)
        {
            GetComponent<Animation>().Play("Walk");
            print("walking");
        }
        else {
            GetComponent<Animation>().Stop("Walk");
        }
    }

    
}
