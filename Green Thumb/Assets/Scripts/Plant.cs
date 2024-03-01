using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IInteractable
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
	private PlantData.GrowthStage growthStage;

	[SerializeField]
	private GameObject plantInformationCanvasPrefab;
	private GameObject plantInformationCanvas;

	void Awake()
    {
		SetPlantData();
    }

    public void Interact(PlayerController playerController)
    {
        // Based on tool held - watering can will water, soil will change color
    }

    public void GetKnowledge()
    {
		if (plantInformationCanvas == null)
		{
			// Popup window showing the plant's information
			plantInformationCanvas = Instantiate(plantInformationCanvasPrefab);
			plantInformationCanvas.GetComponent<PlantInformationCanvas>().SetPlantInformationPopup(plantData);
		}
		else
		{
			plantInformationCanvas.GetComponent<PlantInformationCanvas>().DestroyPlantInformationPopup();
			plantInformationCanvas = null;
		}
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
			growthStage = plantData.growthStage;
		}
		else
		{
			Debug.LogError($"Plant Data field is empty");
		}
	}
}
