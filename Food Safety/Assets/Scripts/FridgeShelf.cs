using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FridgeShelf : MonoBehaviour
{
	public ShelfType shelfType;

	public enum ShelfType
	{
		TopShelf,
		MiddleShelf,
		BottomShelf,
		SaladShelf
	}
}
