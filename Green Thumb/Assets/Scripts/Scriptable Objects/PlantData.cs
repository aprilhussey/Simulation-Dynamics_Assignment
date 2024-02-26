using UnityEngine;

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

	public enum GrowthStage
	{
		Seed,
		Sprout,
		Seeding,
		Vegetative,
		Budding,
		Flowering,
		Ripening
	}

	public string commonName;
	public string scientificName;

	public PlantType plantType;
	public GrowthStage growthStage;
}
