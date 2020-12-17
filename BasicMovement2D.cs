// Eren Darıcı

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float jumpForce = 0.5f;
    public bool isGrounded = true; // bool variable for checking player's ground condition

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // movement vector
        transform.position += movement * Time.deltaTime * moveSpeed; // transforming position of player to move, multiplying with deltaTime in order to prevent frame issue
        Jump();
    }

    void Jump()
    {   if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // adding impulse to player's rigidbody2d component
        }
    }




}
