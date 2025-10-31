using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Getting Components from Unity
    public GameObject player;
    public Rigidbody rb;
    public Transform target;

    // Declaring Variables
    private Vector3 offset;
    public float sens = 60;

    void Start()
    {
        // Get the distance for the camera to stay at
        offset = transform.position - player.transform.position;

        rb = GetComponent<Rigidbody>();

        //Locks the cursor to the play area and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        // Gets the mouse input from the user
        float mouseX = Input.GetAxisRaw("Mouse X");

        // Rotates the camera around an empty gameObject placed in the player around the Y-axis
        // The user controlls this rotation by moving the mouse left and right 
        transform.RotateAround(target.position, Vector3.up * mouseX, sens);
    }
}