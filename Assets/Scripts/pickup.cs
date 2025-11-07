using UnityEngine;

public class pickup : MonoBehaviour
{
    float Rotatespeed = 3;
    float time;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            //Once the player touches the pickup, the game object is deactivated
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        //rotates the collectible around the y-axis 
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * Rotatespeed);
    }

}
