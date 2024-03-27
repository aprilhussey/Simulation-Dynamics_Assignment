using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantData plantData;

	//[SerializeField]
	private string itemName;

    //[SerializeField]
    private string itemDescription;

	//[SerializeField]
	private string commonName;
	//[SerializeField]
	private string scientificName;

	//[SerializeField]
	private PlantData.PlantType plantType;
	//[SerializeField]
	private GrowthStage[] growthStages;

	private GrowthStage currentGrowthStage;

	void Awake()
    {
		SetPlantData();
    }

    public void Interact(Interactor interactor)
    {
		// Based on tool held - watering can will water, soil will change color
		Debug.Log($"Interacted with {commonName}!");
    }

	private void SetPlantData()
	{
		if (plantData != null)
		{
			if (plantData.itemName != null)
			{
				itemName = plantData.itemName;
			}
			else
			{
				Debug.LogError($"{plantData.name} Item Name field is empty");
			}

			if (plantData.itemDescription != null)
			{
				itemDescription = plantData.itemDescription;
			}
			else
			{
				Debug.LogError($"{plantData.name} Item Description field is empty");
			}

			if (plantData.commonName != null)
			{
				commonName = plantData.commonName;
			}
			else
			{
				Debug.LogError($"{plantData.name} Common Name field is empty");
			}

			if (plantData.scientificName != null)
			{
				scientificName = plantData.scientificName;
			}
			else
			{
				Debug.LogError($"{plantData.name} Scientific Name field is empty");
			}

			plantType = plantData.plantType;
			growthStages = plantData.growthStages;
		}
		else
		{
			Debug.LogError($"Plant Data field is empty");
		}
	}
}
