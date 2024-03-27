using UnityEngine;

[System.Serializable]
public class GrowthStage
{
	public enum Stage
	{
		Seed,
		Sprout,
		Budding,
		Flowering,
	}

	public Stage stage;
	public Sprite stageSprite;
}

[CreateAssetMenu(fileName = "PlantName", menuName = "Scriptable Objects/Plant")]
public class PlantData : ItemData
{
	public enum PlantType
	{
		Flower,
		Succulent,
		Vegetable,
		Fruit
	}

	public string commonName;
	public string scientificName;

	public PlantType plantType;
	public GrowthStage[] growthStages;
}
