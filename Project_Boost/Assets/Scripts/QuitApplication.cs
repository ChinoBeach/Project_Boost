using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        //if the escape key is hit, close the application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc pushed");
            Application.Quit();
        }
        
    }
}
