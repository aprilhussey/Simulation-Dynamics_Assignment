using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeItem : MonoBehaviour
{
	public string itemName;

	[HideInInspector]
	public Vector3 notClickedScale;
	[HideInInspector]
	public Vector3 clickedScale;
	[HideInInspector]
	public Vector3 inFridgeScale;

	public bool isReadyToEat;
	public bool isDairyProduct;
    public bool isMeat;
	public bool isFruitOrVeg;

	private void Awake()
	{
		notClickedScale = this.transform.localScale;
		clickedScale = notClickedScale * 2;
		inFridgeScale = notClickedScale / 2;
	}

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
