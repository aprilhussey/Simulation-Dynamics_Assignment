using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantInformationCanvas : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI itemDescriptionText;

	[SerializeField]
	private TextMeshProUGUI commonNameText;
	[SerializeField]
	private TextMeshProUGUI scientificNameText;

	[SerializeField]
	private TextMeshProUGUI plantTypeText;
	[SerializeField]
	private TextMeshProUGUI growthStageText;

	public void SetPlantInformationPopup(PlantData plantData)
	{
		if (plantData != null)
		{
			if (plantData.itemDescription != null)
			{
				itemDescriptionText.text = plantData.itemDescription;
			}
			else
			{
				Debug.LogError($"{plantData.name} Item Description field is empty");
			}

			if (plantData.commonName != null)
			{
				commonNameText.text = plantData.commonName;
			}
			else
			{
				Debug.LogError($"{plantData.name} Common Name field is empty");
			}

			if (plantData.scientificName != null)
			{
				scientificNameText.text = plantData.scientificName;
			}
			else
			{
				Debug.LogError($"{plantData.name} Scientific Name field is empty");
			}

			plantTypeText.text = plantData.plantType.ToString();
			growthStageText.text = plantData.growthStage.ToString();
		}
		else
		{
			Debug.LogError($"Plant Data field is empty");
		}
	}

	public void DestroyPlantInformationPopup()
	{
		Destroy(this.gameObject);
	}
}
