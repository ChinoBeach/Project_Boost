using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //class variables 
    int intCurrentSceneIndex = 0;
    int intMaxLevelIndex;
    bool bolHasPlayerInteracted = false;

   // bool bolIsTransitioning = false; did not do this along with the video because i did this myself during the last section as bolHasInteracted. 

    //member variables
    [SerializeField] float fltInvokeSec = 1f;

    //audio variables 
    AudioSource audioSourcePlayer;
    [SerializeField] AudioClip audioSuccess;
    [SerializeField] AudioClip audioCrash;

    private void Start()
    {
        //set up the max level index
        intMaxLevelIndex = (SceneManager.sceneCountInBuildSettings - 1);

        //set up the audio source
        audioSourcePlayer = GetComponent<AudioSource>();

    }

    //when the object hits something
    private void OnCollisionEnter(Collision other)
    {
        //get the current scene index
        intCurrentSceneIndex = GetCurrentSceneIndex();

        //if the player has already interactued with something, dont do anything:
        if (bolHasPlayerInteracted) { return; }

        //switch statements looking at what the player is colliding with based off of the tag
        switch (other.gameObject.tag)
        {
            //if the player runs into something tagged as friendly
            case "Friendly":

                //print message
                Debug.Log("This this is friendly");
                break;

            //if the player runs into something tagged as Finish
            case "Finish":
                //print message
                Debug.Log("Level Finished");

                //load the next level
                StartSuccessSequence();
                break;

           /* //if the player runs into something tagged as Fuel
            case "Fuel":

                //print message
                Debug.Log("Fuel Aquired");
                break;
           */

            //if the player runs into something that isnt tagged, or doesnt match a tag above
            default:
                //print message
                Debug.Log("Explosion Detetect. Ship Lost.");

                //disable the movement and reload the scene
                StartCrashSequence();
                break;
        }
       
    }

    int GetCurrentSceneIndex()
    {
        //retrieve current Scene 
        intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        return intCurrentSceneIndex;
    }
    void ReloadLevel()
    {
        //reload the scene
        SceneManager.LoadScene(intCurrentSceneIndex);
        //restart interactoion
        bolHasPlayerInteracted = false;
    }

    void LoadNextLevel()
    {
        //if your not at the end of the index,
        if(intCurrentSceneIndex < intMaxLevelIndex)
        {
            //increment current level
            intCurrentSceneIndex++;

        }
        else
        {
            //go back to the start
            intCurrentSceneIndex = 0;
        }

        //load new level
        SceneManager.LoadScene(intCurrentSceneIndex);
    }

    void SetMovementFalse()
    {
        //retrieve the movemenet script componenet from the player and disable it
        GetComponent<Movement>().enabled = false;

    }
    void StartCrashSequence()
    {
        //tell the player that its interacted 
        bolHasPlayerInteracted = true;

        //turn off the movement
        SetMovementFalse();

        //turn off other sounds
        audioSourcePlayer.Stop();

        //play crash sound
        audioSourcePlayer.PlayOneShot(audioCrash);

        //reload the level after a delay 
        Invoke("ReloadLevel", fltInvokeSec);

        
    }

    void StartSuccessSequence()
    {
        //tell the player that its interacted 
        bolHasPlayerInteracted = true;

        //turn off the movement
        SetMovementFalse();

        //turn off other sounds
        audioSourcePlayer.Stop();

        //play success sound
        audioSourcePlayer.PlayOneShot(audioSuccess);

        //load the next level after a delay
        Invoke("LoadNextLevel", fltInvokeSec);

    }
}
