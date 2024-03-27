using UnityEngine;
using UnityEngine.UI;

public abstract class ItemData : ScriptableObject
{
	// Shared characteristics between all items
	public string itemName;

	[TextArea(3,20)]
	public string itemDescription;
}
