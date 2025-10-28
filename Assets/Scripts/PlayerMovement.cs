using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.SceneManagement.SceneManager;

public class PlayerMovement : MonoBehaviour
{
    
    //Decalring Variables
    private float movementX;
    private float movementY;

    public float speed = 0;
    public int score = 0;

    private Boolean grounded;

    //Getting Components from unity
    private Rigidbody rb;
    public Camera camera;
    

    void Start()
    {
        //Getting the rigid body that is on the player already
        rb = GetComponent<Rigidbody>();
        grounded = true;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //Adds force to the rigid body depending on where the camera is facing and what inputs the user does
        rb.AddForce(camera.transform.forward * movement.z * speed);
        rb.AddForce(camera.transform.right * movement.x * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the collider the player passes through has the tag pickup then adds one to the variable 'score'
        if(other.transform.tag == "Pickup")
        {
            score = score + 1;
            Debug.Log(score);
        }

        // Checks if the player has passed though the collider with the tag border, if so, it calls the restart function
        if (other.transform.tag == "Border")
        {
            Restart();
        }
    }

    // Reloads the current scene
    public void Restart()
    {
        LoadScene(GetActiveScene().buildIndex);
    }
}
