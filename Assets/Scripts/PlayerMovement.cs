using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEngine.SceneManagement.SceneManager;

public class PlayerMovement : MonoBehaviour
{

    //Decalring Variables
    private float movementX;
    private float movementY;

    public float speed = 0;
    public int score = 0;
    public float jumpForce = 5;

    private Boolean isGrounded = true;

    //Getting Components from unity
    private Rigidbody rb;
    public Camera camera;


    void Start()
    {
        //Getting the rigid body that is on the player already
        rb = GetComponent<Rigidbody>();

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

        //Gets input space input from player and checks if the player is on the ground
        if (Input.GetButton("Jump") && isGrounded)
        {
            //adds a velocity to the y-axis while keeping the current velocity of the x and z axis
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);

            //makes the player unable to jump again until they hit an object with the tag floor
            isGrounded = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Checks if the player has passed though the collider with the tag border, if so, it calls the restart function
        if (other.transform.tag == "Border")
        {
            //calls the restart function
            Restart();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            //Makes isGrounded true once the player hits a game object with the tag "Floor", allows the player to jump again
            isGrounded = true;
        }
    }

    // Reloads the current scene
    public void Restart()
    {
        //Reloads the current scene
        LoadScene(GetActiveScene().buildIndex);
    }


}
