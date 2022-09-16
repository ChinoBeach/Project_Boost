using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //member variable
    Rigidbody rigidbodyPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        //instantiate(cache) the rigidbody
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        //if the player is holding space.
        if(Input.GetKey(KeyCode.Space))
        {
            //print message
            //Debug.Log("Pressed SPACE -- Thrusting");
            //make the player go up (vector3 0,1,0)
            rigidbodyPlayer.AddRelativeForce(Vector3.up);
        }

    }

    void ProcessRotation()
    {
        //if the player is holding a or left arrow
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //print message
            Debug.Log("Rotating Left");
        }

        //else if the player is holding d or right arrow 
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //print message
            Debug.Log("Rotating Right");
        }
    }
}
