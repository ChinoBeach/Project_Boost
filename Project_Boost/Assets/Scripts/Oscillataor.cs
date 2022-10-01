using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillataor : MonoBehaviour
{
    //variables 
    Vector3 vectorStartingPos;                               // starting position of object

    [SerializeField]Vector3 vectorMovement;                  // how much we want it to move out
    float  fltMovementFactor;   // oscioation control
    [SerializeField] float fltPeriod = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //get the starting postion 
        vectorStartingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //variables
        const float fltTau = Mathf.PI * 2;                      //contastnt value of 6.283

        float fltCycles = Time.time / fltPeriod;                //contilly growing over time
        float fltRawSinWave = Mathf.Sin(fltCycles * fltTau);    //going from -1 to 1

        fltMovementFactor = (fltRawSinWave + 1f) / 2f;          //recaulcutaed to go from 0 to 1

        //set the offset
        Vector3 offset = vectorMovement * fltMovementFactor;

        //move the object
        transform.position = vectorStartingPos + offset;
    }
}
