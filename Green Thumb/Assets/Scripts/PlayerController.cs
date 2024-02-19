using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Player
    [SerializeField]
    private float speed = 10f;
	[SerializeField]
	private float rotationSpeed = 100f;

    // Rigidbody
    private Rigidbody playerRigidbody;

    // Input actions variables
    private Vector2 movementInput;

    void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();

        // Set input actions variables
        movementInput = Vector2.zero;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        playerRigidbody.velocity = movement * speed;
        playerRigidbody.angularVelocity = Vector3.zero;

        if (movement != Vector3.zero)
        {
            // Calculate the rotation direction based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

            // Smoothly interpolate to the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Performed)
        {
            movementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            movementInput = Vector2.zero;
        }
    }
}
