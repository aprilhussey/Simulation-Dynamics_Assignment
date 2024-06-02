using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    private string hazardName;

    [SerializeField]
    private HazardType primaryHazardType;

    [SerializeField]
    private HazardType secondaryHazardType;

    [TextArea(0, 10)]
    public string hazardClickedDescription;

    private bool isHazardFound = false;

    public enum HazardType
    {
        None,
        TripHazard,
        KnockHazard,
        SlipHazard,
        BurnHazard,
        CrossContamination,
        OverflowingTrash,
    }

    public void ClickedAction()
    {
        isHazardFound = true;

        switch (hazardName)
        {
            case "Pan":
                this.transform.rotation = Quaternion.Euler(0, 100, 0);
                break;
            case "Oven Door":
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "Pot":
                this.transform.position = new Vector3(1.837f, 1.152738f, 0.903f);
                break;
        }
    }

    public string GetHazardName
    {
        get { return hazardName; }
    }

    public HazardType GetPrimaryHazardType
    {
        get { return primaryHazardType; }
    }

    public HazardType GetSecondaryHazardType
    {
        get { return secondaryHazardType; }
    }

    public string GetHazardClickedDescription
    {
        get { return hazardClickedDescription; }
    }

    public bool GetIsHazardFound
    {
        get { return isHazardFound; }
    }
}
