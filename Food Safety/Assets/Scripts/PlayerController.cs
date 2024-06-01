using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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

	int fridgeShelfLayerMask;
	private FridgeShelf.FridgeShelfType fridgeShelfType;

	[SerializeField]
	private GameObject prefabCanvasInformationPopup;

	private void Awake()
	{
		mainCamera = Camera.main;

		// Input actions
		playerInput = this.GetComponent<PlayerInput>();
		inputActionAsset = playerInput.actions;
		playerActionMap = inputActionAsset.FindActionMap("Player");
		
		inputActionAsset.Enable();

		fridgeShelfLayerMask = LayerMask.GetMask("FridgeShelf");
	}

	private void OnEnable()
	{
		playerActionMap["Click"].performed += OnClickPerformed;
		playerActionMap["Click"].canceled += context => { isDragging = false; };

		playerActionMap["ScreenPosition"].performed += context => { screenPosition = context.ReadValue<Vector2>(); };

		playerActionMap["Information"].performed += OnInformationPerformed;
	}

	private void OnDisable()
	{
		playerActionMap["Click"].performed -= OnClickPerformed;
        playerActionMap["Information"].performed -= OnInformationPerformed;
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
				GameObject fridgeItemObject = hit.transform.GetComponent<FridgeItem>().gameObject;
				StartCoroutine(Drag(fridgeItemObject));
			}
		}
	}

	private IEnumerator Drag(GameObject gameObject)
	{
		FridgeItem fridgeItem = gameObject.GetComponent<FridgeItem>();

		isDragging = true;

		Vector3 offset = gameObject.transform.position - GetWorldPositionOfGameObject(gameObject);

		while (isDragging)
		{
			gameObject.transform.position = GetWorldPositionOfGameObject(gameObject) + offset;

			if (GameObjectIsOverShelf())
			{
				gameObject.transform.localScale = fridgeItem.GetInFridgeScale;
			}
			else
			{
				gameObject.transform.localScale = fridgeItem.GetClickedScale;
			}

			yield return null;
		}

		if (GameObjectIsOverShelf())
		{
			gameObject.transform.localScale = fridgeItem.GetInFridgeScale;
			fridgeItem.SetOnFridgeShelfType(fridgeShelfType);
			//Debug.Log($"fridgeShelfType: {fridgeShelfType}");
		}
		else
		{
			gameObject.transform.localScale = fridgeItem.GetNotClickedScale;
			fridgeItem.SetOnFridgeShelfType(fridgeShelfType);
			//Debug.Log($"fridgeShelfType: {fridgeShelfType}");
		}
	}

	private Vector3 GetWorldPositionOfGameObject(GameObject gameObject)
	{
		float z = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
		return mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, z));
	}

	private bool GameObjectIsOverShelf()
	{
		Ray ray = mainCamera.ScreenPointToRay(screenPosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity, fridgeShelfLayerMask))
		{
			if (hit.transform.GetComponent<FridgeShelf>() != null)
			{
				//Debug.Log($"hit shelf: {hit.transform.gameObject.name}");
				fridgeShelfType = hit.transform.GetComponent<FridgeShelf>().GetFridgeShelfType;
				return true;
			}
		}
		else
		{
			fridgeShelfType = FridgeShelf.FridgeShelfType.None;
		}
		return false;
	}

	private void OnInformationPerformed(InputAction.CallbackContext context)
	{
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<FridgeItem>() != null)
            {
				FridgeItem fridgeItem = hit.transform.GetComponent<FridgeItem>();
                GameObject fridgeItemObject = fridgeItem.gameObject;

				GameObject canvasInformationPopup = Instantiate(prefabCanvasInformationPopup);
				canvasInformationPopup.GetComponent<Canvas>().worldCamera = mainCamera;

				GameObject informationPopup = canvasInformationPopup.transform.Find("Information Popup").gameObject;
				informationPopup.SetActive(false);

				TMP_Text txtInformationPopup = informationPopup.GetComponentInChildren<TMP_Text>();

                txtInformationPopup.text = fridgeItem.GetItemName;
                informationPopup.transform.position = new Vector3(fridgeItemObject.transform.position.x, fridgeItemObject.transform.position.y, informationPopup.transform.position.z);
                StartCoroutine(ShowInformationPopupAndHide(informationPopup));
            }
        }
    }

    private IEnumerator ShowInformationPopupAndHide(GameObject informationPopup)
    {
        informationPopup.SetActive(true);

        yield return new WaitForSeconds(5f);

        Destroy(informationPopup);
    }
}
