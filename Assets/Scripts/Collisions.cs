using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class CollisionScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            Destroy(gameObject);
            LoadScene(GetActiveScene().buildIndex);
        }
    }
}

