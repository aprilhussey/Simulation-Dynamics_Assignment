using UnityEngine;

[CreateAssetMenu(fileName = "ToolName", menuName = "Scriptable Objects/Tool")]
public class ToolData : ItemData
{
    public enum ToolType
    {
        Trowel,
        WateringCan,
    }

    public ToolType toolType;
}
