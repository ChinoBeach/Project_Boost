using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillataor : MonoBehaviour
{
    //variables 
    Vector3 vectorStartingPos;                               // starting position of object

    [SerializeField]Vector3 vectorMovement;                  // how much we want it to move out
    [SerializeField] [Range(0,1)]float  fltMovementFactor;   // oscioation control


    // Start is called before the first frame update
    void Start()
    {
        //get the starting postion 
        vectorStartingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //set the offset
        Vector3 offset = vectorMovement * fltMovementFactor;

        //move the object
        transform.position = vectorStartingPos + offset;
    }
}
