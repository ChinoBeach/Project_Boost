using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //when the object hits something
    private void OnCollisionEnter(Collision other)
    {
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

    void ReloadLevel()
    {
        //current Scene 
        int intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //reload the scene
        SceneManager.LoadScene(intCurrentSceneIndex);
    }
}
