using UnityEngine;

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
                Debug.Log("This this is friendly");
                break;

            //if the player runs into something tagged as Finish
            case "Finish":
                Debug.Log("Level Finished");
                break;

            //if the player runs into something tagged as Fuel
            case "Fuel":
                Debug.Log("Fuel Aquired");
                break;

            //if the player runs into something that isnt tagged, or doesnt match a tag above
            default:
                Debug.Log("Explosion Detetect. Ship Lost.");
                break;
        }
       
    }
}
