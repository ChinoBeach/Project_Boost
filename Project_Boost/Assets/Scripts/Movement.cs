using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //member variables for movement 
    Rigidbody rigidbodyPlayer;
    [SerializeField] float fltMainThrust = 1000f;
    [SerializeField] float fltRotationThrust = 100f;
   

    //varaibles for sound
    AudioSource audioSourcePlayer;
    [SerializeField] AudioClip audioEngine;

    // Start is called before the first frame update
    void Start()
    {
        //cache the rigidbody
        rigidbodyPlayer = GetComponent<Rigidbody>();

        //cache the audioSource
        audioSourcePlayer = GetComponent<AudioSource>();
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
            //make the player go up (vector3 0,1,0) mulitplied by the speed and make it framerate independent
            rigidbodyPlayer.AddRelativeForce(Vector3.up * fltMainThrust * Time.deltaTime);

            //if the music isnt already playing
            if (!audioSourcePlayer.isPlaying)
            {
                //start the music connected to the audiosource
                //audioSourcePlayer.Play();

                //play the audioclip for the engines
                audioSourcePlayer.PlayOneShot(audioEngine);
            }
        }
        //when you are not thrusting (holding space) 
        else
        {
            //stop any playing music
            audioSourcePlayer.Stop();
        }

    }

    void ProcessRotation()
    {
        //if the player is holding a or left arrow
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //rotate the player left
            ApplyRotation(fltRotationThrust);
        }

        //else if the player is holding d or right arrow 
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            //rotate the player right
            ApplyRotation(-fltRotationThrust);
        }
    }

    private void ApplyRotation( float fltRotationThisFrame)
    {
        //freezing rotation so we can manually rotate.
        rigidbodyPlayer.freezeRotation = true;
        
        // manually rotate the player
        transform.Rotate(Vector3.forward * fltRotationThisFrame * Time.deltaTime);

        //unfreeze rotation so pyschics can take over
        rigidbodyPlayer.freezeRotation = false;
    }


}
