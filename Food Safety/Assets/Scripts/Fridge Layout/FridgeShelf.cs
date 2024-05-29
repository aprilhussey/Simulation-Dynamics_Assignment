using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FridgeShelf : MonoBehaviour
{
	public FridgeShelfType fridgeShelfType;

	public enum FridgeShelfType
	{
		None,
		TopShelf,
		MiddleShelf,
		BottomShelf,
		SaladDrawer
	}

	public FridgeShelfType GetFridgeShelfType
	{
		get { return fridgeShelfType; }
	}
}
