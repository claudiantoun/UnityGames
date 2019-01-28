using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 2f, mouseSensitivity = 2f, jumpForce = 2f;
    private float playerMovementFB, playerMovementLR, mouseRotationX, mouseRotationY, verticalVelocity;
    private bool hasJumped, isCrouched;
    public GameObject eyes;
    CharacterController player;

    // Use this for initialization
    void Start ()
    {
        player = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Crouch"))
        {
            if (isCrouched == true)
            {
                player.height = player.height / 2;
                isCrouched = false;
            }
            else
            {
                player.height = player.height * 2;
                isCrouched = true;
            }
        }

        ApplyGravity();
    }

    void Movement()
    {
        playerMovementFB = Input.GetAxis("Vertical") * playerSpeed;
        playerMovementLR = Input.GetAxis("Horizontal") * playerSpeed;

        mouseRotationX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseRotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        Vector3 movement = new Vector3(playerMovementLR, verticalVelocity, playerMovementFB);
        transform.Rotate(0, mouseRotationX, 0);
        eyes.transform.localRotation = Quaternion.Euler(mouseRotationY, 0, 0);
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        hasJumped = true;
    }

    private void ApplyGravity()
    {
        if (player.isGrounded == true)
        {
            if (hasJumped == false)
            {
                verticalVelocity = Physics.gravity.y;
            }
            else
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            verticalVelocity = Mathf.Clamp(verticalVelocity, -50f, jumpForce);
            hasJumped = false;
        }
    }
}
