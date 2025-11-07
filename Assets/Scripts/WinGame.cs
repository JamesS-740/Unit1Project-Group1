using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject player;

    //calls the Collisions
    Collisions score;

    //Keeps the variable private while allowing us the edit how many points are required to finish the game, we can do this in the inspector
    [SerializeField] int scoreRequirement = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Makes the variable score have the same variables as the public Collision variables
        score = player.GetComponent<Collisions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && score.score >= scoreRequirement)
        {
            //if the player has the correct amount of points and they hit the collider, they win the game
            Debug.Log("You win");
        }
    }
}
