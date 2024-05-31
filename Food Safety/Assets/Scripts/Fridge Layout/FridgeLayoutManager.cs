using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class FridgeLayoutManager : MonoBehaviour
{
    private FridgeItem[] fridgeItems;

	public GameObject popup;
	public TMP_Text txtPopup;

	public GameObject btnConfirm;
	public GameObject btnReturnToTrainingMenu;

	[Header("Popup Text")]
	[TextArea(0,10)]
	public string txtAllFridgeItemsNotOnCorrectShelves;
	[TextArea(0, 10)]
	public string txtAllFridgeItemsOnCorrectShelves;

	[Header("DebugButtons")]
	public GameObject debugButtons;

    // Input actions
    private PlayerInput playerInput;
    private InputActionAsset inputActionAsset;
    private InputActionMap playerActionMap;

    private void Awake()
	{
		// Fridge layout
        fridgeItems = GameObject.FindObjectsOfType<FridgeItem>();

		popup.SetActive(false);

		btnConfirm.SetActive(false);
		btnReturnToTrainingMenu.SetActive(false);

		// Debug
		debugButtons.SetActive(false);

        // Input actions
        playerInput = GameObject.FindObjectOfType<PlayerInput>();
        inputActionAsset = playerInput.actions;
        playerActionMap = inputActionAsset.FindActionMap("Player");

        inputActionAsset.Enable();
    }

    private void Update()
	{
		if (AllFridgeItemsAreOnAShelf() && !btnReturnToTrainingMenu.activeInHierarchy)
		{
			btnConfirm.SetActive(true);
		}
		else
		{
			btnConfirm.SetActive(false);
		}
	}

	public bool AllFridgeItemsAreOnAShelf()
	{
		if (!debugButtons.activeInHierarchy)
		{
			foreach (FridgeItem fridgeItem in fridgeItems)
			{
				if (fridgeItem.GetOnFridgeShelfType == FridgeShelf.FridgeShelfType.None)
				{
					return false;
				}
			}
		}
		else
		{
			foreach (FridgeItem fridgeItem in fridgeItems)
			{
				if (fridgeItem.GetOnFridgeShelfType != fridgeItem.GetGoesOnFridgeShelfType)
				{
					return false;
				}
			}
		}
		return true;
	}

	public void CheckFridgeItemsAreOnCorrectShelves()
	{
		foreach (FridgeItem fridgeItem in fridgeItems)
		{
			if (fridgeItem.GetOnFridgeShelfType != fridgeItem.GetGoesOnFridgeShelfType)
			{
				fridgeItem.ResetToNotClickedState();

				if (!popup.activeInHierarchy)
				{
					txtPopup.text = txtAllFridgeItemsNotOnCorrectShelves;
					StartCoroutine(ShowPopupAndHide());
				}
			}
			else if (fridgeItem.GetOnFridgeShelfType == fridgeItem.GetGoesOnFridgeShelfType)
			{
				if (!popup.activeInHierarchy)
				{
					Time.timeScale = 0f;

					txtPopup.text = txtAllFridgeItemsOnCorrectShelves;
					popup.SetActive(true);

					btnReturnToTrainingMenu.SetActive(true);
				}
			}
		}
	}

	private IEnumerator ShowPopupAndHide()
	{
		popup.SetActive(true);

		yield return new WaitForSeconds(5f);

		popup.SetActive(false);
	}

	// Debug
	private void OnDebugPerformed(InputAction.CallbackContext context)
	{
		if (!DebugButtonsActive())
		{
            DebugShowDebugButtons();
        }
		else
		{
			DebugHideDebugButtons();
		}
	}

	public void DebugShowDebugButtons()
	{
		debugButtons.SetActive(true);
	}

	public void DebugHideDebugButtons()
	{
		debugButtons.SetActive(false);
	}

	public void DebugSetItemsToCorrectShelves()
	{
		foreach (FridgeItem fridgeItem in fridgeItems)
		{
			if (fridgeItem.GetOnFridgeShelfType != fridgeItem.GetGoesOnFridgeShelfType)
			{
				fridgeItem.SetOnFridgeShelfType(fridgeItem.GetGoesOnFridgeShelfType);
            }
		}
	}

	public void DebugSetItemsToOnNoShelves()
	{
		foreach (FridgeItem fridgeItem in fridgeItems)
		{
            if (fridgeItem.GetOnFridgeShelfType != FridgeShelf.FridgeShelfType.None)
            {
                fridgeItem.SetOnFridgeShelfType(FridgeShelf.FridgeShelfType.None);
            }
        }
	}

	public bool DebugButtonsActive()
	{
		return debugButtons.activeInHierarchy;
	}

    private void OnEnable()
    {
        playerActionMap["Debug"].performed += OnDebugPerformed;
    }

    private void OnDisable()
    {
        playerActionMap["Debug"].performed -= OnDebugPerformed;
    }
}
