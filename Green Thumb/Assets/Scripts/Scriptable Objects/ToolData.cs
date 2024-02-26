using UnityEngine;

[CreateAssetMenu(fileName = "ToolName", menuName = "Scriptable Objects/Tool")]
public class ToolData : ItemData
{
    public enum ToolType
    {
        Shovel,
        WateringCan,
    }

    public ToolType toolType;
}
