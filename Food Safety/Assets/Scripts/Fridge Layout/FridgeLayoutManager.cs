using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
	public GameObject btnShowDebugButtons;
	public GameObject btnHideDebugButtons;
	public GameObject debugButtons;

	private void Awake()
	{
		fridgeItems = GameObject.FindObjectsOfType<FridgeItem>();

		popup.SetActive(false);

		btnConfirm.SetActive(false);
		btnReturnToTrainingMenu.SetActive(false);

		btnShowDebugButtons.SetActive(true);
		btnHideDebugButtons.SetActive(false);
		debugButtons.SetActive(false);
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
				if (!fridgeItem.onCorrectShelf)
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
			if (!fridgeItem.onCorrectShelf)
			{
				fridgeItem.ResetToNotClickedState();

				if (!popup.activeInHierarchy)
				{
					txtPopup.text = txtAllFridgeItemsNotOnCorrectShelves;
					StartCoroutine(ShowPopupAndHide());
				}
			}
			else if (fridgeItem.onCorrectShelf)
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
	public void DebugShowDebugButtons()
	{
		debugButtons.SetActive(true);
		btnShowDebugButtons.SetActive(false);
		btnHideDebugButtons.SetActive(true);
	}

	public void DebugHideDebugButtons()
	{
		debugButtons.SetActive(false);
		btnShowDebugButtons.SetActive(true);
		btnHideDebugButtons.SetActive(false);
	}

	public void DebugSetItemsToCorrectShelves()
	{
		foreach (FridgeItem fridgeItem in fridgeItems)
		{
			fridgeItem.onCorrectShelf = true;
		}
	}

	public void DebugSetItemsToOnNoShelves()
	{
		foreach (FridgeItem fridgeItem in fridgeItems)
		{
			fridgeItem.onCorrectShelf = false;
		}
	}

	public bool DebugButtonsActive()
	{
		return debugButtons.activeInHierarchy;
	}
}
