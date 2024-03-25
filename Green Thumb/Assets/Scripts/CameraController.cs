using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private GameObject mainCamera;

	[SerializeField]
	private float panSpeed = 10f;
	[SerializeField]
	private float zoomSpeed = 10f;

	[SerializeField]
	private float xAngle = 45f;
	private float yAngle = 0f;
	private float zAngle = 0f;

	private void Awake()
	{
		mainCamera.transform.rotation = Quaternion.Euler(xAngle, yAngle, zAngle);
	}

	public void OnPan(InputAction.CallbackContext context)
    {
        Vector2 delta = context.ReadValue<Vector2>();

		Vector3 movement = new Vector3(-delta.x, 0, -delta.y) * panSpeed * Time.deltaTime;  // Pan affects the x and z axis
        this.transform.Translate(movement, Space.World);
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        float zoom = context.ReadValue<Vector2>().y;

		// Set rotation of camera
		Quaternion rotation = Quaternion.Euler(xAngle, yAngle, zAngle);

		// Calculate the forward direction based on the rotation
		Vector3 calculatedForward = rotation * Vector3.forward;

		// Zoom happens along the calculated forward direction
		Vector3 movement = zoom * zoomSpeed * Time.deltaTime * calculatedForward;
        this.transform.Translate(movement, Space.Self);
    }
}
