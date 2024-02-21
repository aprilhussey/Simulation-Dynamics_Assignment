using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public enum growthStage
    {
        Sprout,
        Seeding,
        Vegetative,
        Budding,
        Flowering,
        Ripening
    }

    public enum itemType
    {
        Flower,
        Vegetable,
        Fruit,

    }

    // Shared characteristics between all items
    public string itemName;
    
}
