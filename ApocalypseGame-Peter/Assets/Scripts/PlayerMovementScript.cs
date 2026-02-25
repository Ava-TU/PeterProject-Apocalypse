using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float gravity;

    public Transform groundCheck;
    public float groundDistance; //Radius of sphere that does the ground check
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //If the player is on the ground that is in the ground layer, the bool is set to true

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; //this forces the player down on the ground to effectively reset the velocity
            //this helps with the gravity because without this, the player would instantly drop from edges to fast
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //does the movement based on the local coordinates

        controller.Move(move * speed * Time.deltaTime); //Moves using the character controller

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); //applies velocity & gravity to player
    }
}
