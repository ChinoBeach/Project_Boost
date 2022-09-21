using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //class variables 
    int intCurrentSceneIndex = 0;
    int intMaxLevelIndex;

    private void Start()
    {
        //set up the max level index
        intMaxLevelIndex = (SceneManager.sceneCountInBuildSettings - 1);

    }

    //when the object hits something
    private void OnCollisionEnter(Collision other)
    {
        //get the current scene index
        intCurrentSceneIndex = GetCurrentSceneIndex();

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
                LoadNextLevel();

                break;

            //if the player runs into something tagged as Fuel
            case "Fuel":

                //print message
                Debug.Log("Fuel Aquired");
                break;

            //if the player runs into something that isnt tagged, or doesnt match a tag above
            default:

                //print message
                Debug.Log("Explosion Detetect. Ship Lost.");

                //reload the level
                ReloadLevel();
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
}
