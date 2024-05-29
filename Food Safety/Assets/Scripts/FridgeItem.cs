using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeItem : MonoBehaviour
{
	public string itemName;

	public bool isReadyToEat;
	public bool isDairyProduct;
    public bool isMeat;
	public bool isFruitOrVeg;

	public string GetItemName
	{
		get { return itemName; }
	}

	public bool GetIsReadyToEat
	{
		get { return isReadyToEat; }
	}

	public bool GetIsDairyProduct
	{
		get { return isDairyProduct; }
	}

	public bool GetIsMeat
	{
		get { return isMeat; }
	}

	public bool GetIsFruitOrVeg
	{
		get { return isFruitOrVeg; }
	}
}
