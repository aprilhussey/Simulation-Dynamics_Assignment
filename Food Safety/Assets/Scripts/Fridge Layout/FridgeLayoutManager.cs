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

	private void Awake()
	{
		fridgeItems = GameObject.FindObjectsOfType<FridgeItem>();

		popup.SetActive(false);

		btnConfirm.SetActive(false);
		btnReturnToTrainingMenu.SetActive(false);
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
}
