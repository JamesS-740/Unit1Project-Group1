using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.SceneManagement.SceneManager;
using TMPro;

public class CollisionScript : MonoBehaviour
{

    int score = 0;
    public TextMeshProUGUI text;

    private void Start()
    {
        countScore();
    }

    private void Update()
    {
        countScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            Destroy(gameObject);
            LoadScene(GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the collider the player passes through has the tag pickup then adds one to the variable 'score'
        if (other.transform.tag == "Pickup")
        {
            score = score + 1;
            Debug.Log(score);
        }
    }

    void countScore()
    {
        text.text = "Score: " + score + "/25";
    }
}
