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

	[Header("Popup Text Remember Specifics")]
	public string txtRemember;
    [TextArea(0, 10)]
    public string txtReadyToEatNotOnCorrectShelf;
    [TextArea(0, 10)]
    public string txtDairyProductNotOnCorrectShelf;
    [TextArea(0, 10)]
    public string txtRawMeatNotOnCorrectShelf;
    [TextArea(0, 10)]
    public string txtFruitOrVegNotOnCorrectShelf;

	private bool showReadyToEatText = false;
	private bool showDairyProductText = false;
    private bool showRawMeatText = false;
    private bool showFruitOrVegText = false;

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
		foreach (FridgeItem fridgeItem in fridgeItems)
		{
			if (fridgeItem.GetOnFridgeShelfType == FridgeShelf.FridgeShelfType.None)
			{
				return false;
			}
		}
		return true;
	}

	public void CheckFridgeItemsAreOnCorrectShelves()
	{
		showReadyToEatText = false;
		showDairyProductText = false;
		showRawMeatText = false;
		showFruitOrVegText = false;

		foreach (FridgeItem fridgeItem in fridgeItems)
		{
			if (fridgeItem.GetOnFridgeShelfType != fridgeItem.GetGoesOnFridgeShelfType)
			{
				fridgeItem.ResetToNotClickedState();
                SetBoolsForPopupRememberSpecifics(fridgeItem);
			}
		}

		if (showReadyToEatText || showDairyProductText || showRawMeatText || showFruitOrVegText)
		{
			if (!popup.activeInHierarchy)
			{
				txtPopup.text = txtAllFridgeItemsNotOnCorrectShelves + "\n" + "\n" + txtRemember;

				if (showReadyToEatText)
				{
					txtPopup.text = txtPopup.text + "\n" + txtReadyToEatNotOnCorrectShelf;
				}

				if (showDairyProductText)
				{
					txtPopup.text = txtPopup.text + "\n" + txtDairyProductNotOnCorrectShelf;
				}

				if (showRawMeatText)
				{
					txtPopup.text = txtPopup.text + "\n" + txtRawMeatNotOnCorrectShelf;
				}

				if (showFruitOrVegText)
				{
					txtPopup.text = txtPopup.text + "\n" + txtFruitOrVegNotOnCorrectShelf;
				}

				StartCoroutine(ShowPopupAndHide());
			}
        }
        else if (!showReadyToEatText && !showDairyProductText && !showRawMeatText && !showFruitOrVegText)
		{
			if (!popup.activeInHierarchy)
			{
				Time.timeScale = 0f;

				txtPopup.text = txtAllFridgeItemsOnCorrectShelves;
				popup.SetActive(true);

				btnReturnToTrainingMenu.SetActive(true);
			}
            else
            {
				Time.timeScale = 1f;
            }
        }
    }

    private void SetBoolsForPopupRememberSpecifics(FridgeItem fridgeItem)
	{
		switch (fridgeItem.GetGoesOnFridgeShelfType)
		{
			case FridgeShelf.FridgeShelfType.TopShelf:
				showReadyToEatText = true;
				break;
			case FridgeShelf.FridgeShelfType.MiddleShelf:
				showDairyProductText = true;
				break;
			case FridgeShelf.FridgeShelfType.BottomShelf:
				showRawMeatText = true;
				break;
			case FridgeShelf.FridgeShelfType.SaladDrawer:
				showFruitOrVegText = true;
				break;
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
        if (!debugButtons.activeInHierarchy)
        {
            debugButtons.SetActive(true);
        }
        else
        {
            debugButtons.SetActive(false);
        }
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

    public void DebugSetItemsToOnTopShelf()
    {
        foreach (FridgeItem fridgeItem in fridgeItems)
        {
                fridgeItem.SetOnFridgeShelfType(FridgeShelf.FridgeShelfType.TopShelf);
        }
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
