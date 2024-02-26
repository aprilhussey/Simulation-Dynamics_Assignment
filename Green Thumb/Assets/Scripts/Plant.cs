using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IInteractable
{
    [SerializeField]
    private PlantData plantData;

	[SerializeField]
	private string itemName;

	[SerializeField]
	private string commonName;
	[SerializeField]
	private string scientificName;

	[SerializeField]
	private PlantData.PlantType plantType;
	[SerializeField]
	private PlantData.GrowthStage growthStage;

    void Awake()
    {
        itemName = plantData.itemName;
        
        commonName = plantData.commonName;
        scientificName = plantData.scientificName;

        plantType = plantData.plantType;
        growthStage = plantData.growthStage;
    }

    public void Interact()
    {
        // Popup window that has multiple options
        // Buttons might include:
        // - Water
        // - Fertilize
        // - Move pot
    }
}
