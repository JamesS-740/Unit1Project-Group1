using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.SceneManagement.SceneManager;
using TMPro;

public class CollisionScript : MonoBehaviour
{
    //Declaring variables and getting the UI feature 'text'
    int score = 0;
    public TextMeshProUGUI text;

    private void Start()
    {
    //Calls the countScore() function
        countScore();
    }

    private void Update()
    {
        //Calls the countScore() function
        countScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            // Destroys the player if they hit the game object with the tag 'spike'
            //Reloads the scene
            Destroy(gameObject);
            LoadScene(GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the collider the player passes through has the tag pickup then adds one to the variable 'score'
        if (other.transform.tag == "Pickup")
        {
            // Adds one to the current score if the player hits a isTrigger collider with the tag 'pickup'
            score = score + 1;
            Debug.Log(score);
        }
    }

    void countScore()
    {
        // sets the UI text to say the score and the stuff in the quotation marks
        text.text = "Score: " + score + "/25";
    }
}
