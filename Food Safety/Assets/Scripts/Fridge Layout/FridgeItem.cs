using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeItem : MonoBehaviour
{
	[SerializeField]
	private string itemName;

	private Vector3 originalPosition;

	private Vector3 notClickedScale;
	private Vector3 clickedScale;
	private Vector3 inFridgeScale;

	[HideInInspector]
	public FridgeShelf.FridgeShelfType goesOnFridgeShelfType;
	private FridgeShelf.FridgeShelfType onFridgeShelfType = FridgeShelf.FridgeShelfType.None;

	//public bool onCorrectShelf;

	[SerializeField]
	private bool isReadyToEat;
	[SerializeField]
	private bool isDairyProduct;
	[SerializeField]
	private bool isMeat;
	[SerializeField]
	private bool isFruitOrVeg;

	public FridgeLayoutManager fridgeLayoutManager;

	private void Awake()
	{
		originalPosition = this.transform.position;

		notClickedScale = this.transform.localScale;
		clickedScale = notClickedScale * 2;
		inFridgeScale = notClickedScale / 2;

		SetGoesOnFridgeShelfType();
	}

	private void Start()
	{
		fridgeLayoutManager = FindObjectOfType<FridgeLayoutManager>();
	}

	public string GetItemName
	{
		get { return itemName; }
	}

	public Vector3 GetOriginalPosition
	{
		get { return originalPosition; }
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

	public FridgeShelf.FridgeShelfType GetGoesOnFridgeShelfType
	{
		get { return  goesOnFridgeShelfType; }
	}

	private void SetGoesOnFridgeShelfType()
	{
		if (isReadyToEat)
		{
			goesOnFridgeShelfType = FridgeShelf.FridgeShelfType.TopShelf;
		}
		else if (isDairyProduct)
		{
			goesOnFridgeShelfType = FridgeShelf.FridgeShelfType.MiddleShelf;
		}
		else if (isMeat && isReadyToEat)
		{
			goesOnFridgeShelfType = FridgeShelf.FridgeShelfType.TopShelf;
		}
		else if (isMeat && !isReadyToEat)
		{
			goesOnFridgeShelfType = FridgeShelf.FridgeShelfType.BottomShelf;
		}
		else if (isFruitOrVeg)
		{
			goesOnFridgeShelfType = FridgeShelf.FridgeShelfType.SaladDrawer;
		}
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

	public void ResetToNotClickedState()
	{
		this.transform.position = this.GetOriginalPosition;
		this.transform.localScale = this.GetNotClickedScale;
		this.SetOnFridgeShelfType(FridgeShelf.FridgeShelfType.None);
	}
}
