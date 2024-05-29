using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	private Camera mainCamera;

	// Input actions
	private PlayerInput playerInput;
	private InputActionAsset inputActionAsset;
	private InputActionMap playerActionMap;

	private Vector2 screenPosition;
	private Vector3 worldPosition;

	private bool isDragging;

	private void Awake()
	{
		mainCamera = Camera.main;

		// Input actions
		playerInput = this.GetComponent<PlayerInput>();
		inputActionAsset = playerInput.actions;
		playerActionMap = inputActionAsset.FindActionMap("Player");
		
		inputActionAsset.Enable();
	}

	private void OnEnable()
	{
		playerActionMap["Click"].performed += OnClickPerformed;
		playerActionMap["Click"].canceled += context => { isDragging = false; };

		playerActionMap["ScreenPosition"].performed += context => { screenPosition = context.ReadValue<Vector2>(); };
	}

	private void OnDisable()
	{
		playerActionMap["Click"].performed -= OnClickPerformed;
	}

	private void Update()
	{
		//Debug.Log($"screenPosition: {screenPosition}");
		//Debug.Log($"isDragging: {isDragging}");
	}

	private void OnClickPerformed(InputAction.CallbackContext context)
	{
		//Debug.Log($"Click action triggered");

		Ray ray = mainCamera.ScreenPointToRay(screenPosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			if (hit.transform.GetComponent<FridgeItem>() != null)
			{
				FridgeItem fridgeItem = hit.transform.GetComponent<FridgeItem>();
				GameObject fridgeItemObject = hit.transform.GetComponent<FridgeItem>().gameObject;
				Debug.Log($"Hit {fridgeItem.GetItemName}");

				StartCoroutine(Drag(fridgeItemObject));
			}
		}
	}

	private IEnumerator Drag(GameObject gameObject)
	{
		Vector3 orignalGameObjectScale = gameObject.transform.localScale;

		isDragging = true;

		Vector3 offset = gameObject.transform.position - GetWorldPositionOfGameObject(gameObject);

		while (isDragging)
		{
			gameObject.transform.localScale = orignalGameObjectScale * 2;
			gameObject.transform.position = GetWorldPositionOfGameObject(gameObject) + offset;

			yield return null;
		}
		gameObject.transform.localScale = orignalGameObjectScale;
	}

	private Vector3 GetWorldPositionOfGameObject(GameObject gameObject)
	{
		float z = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
		return mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, z));
	}
}
