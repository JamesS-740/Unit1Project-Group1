using UnityEngine;

public class cameraBox : MonoBehaviour
{
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = player.position;
    }
    void Update()
    {
        transform.position = player.position;
    }

}
