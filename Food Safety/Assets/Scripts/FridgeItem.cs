using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeItem : MonoBehaviour
{
	[SerializeField]
	private string itemName;

	private Vector3 notClickedScale;
	private Vector3 clickedScale;
	private Vector3 inFridgeScale;

	private FridgeShelf.FridgeShelfType onFridgeShelfType = FridgeShelf.FridgeShelfType.None;

	[SerializeField]
	private bool isReadyToEat;
	[SerializeField]
	private bool isDairyProduct;
	[SerializeField]
	private bool isMeat;
	[SerializeField]
	private bool isFruitOrVeg;

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

	public Vector3 GetNotClickedScale
	{
		get { return notClickedScale; }
	}

	public Vector3 GetClickedScale
	{
		get { return clickedScale; }
	}

	public Vector3 GetInFridgeScale
	{
		get { return inFridgeScale; }
	}

	public FridgeShelf.FridgeShelfType GetOnFridgeShelfType
	{
		get { return onFridgeShelfType; }
	}

	public void SetOnFridgeShelfType(FridgeShelf.FridgeShelfType newFridgeShelfType)
	{
		onFridgeShelfType = newFridgeShelfType;
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
