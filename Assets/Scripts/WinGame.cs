using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject player;

    PlayerMovement score;
    [SerializeField] int scoreRequirement = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && score.score >= scoreRequirement)
        {
            Debug.Log("You win");
        }
    }
}
