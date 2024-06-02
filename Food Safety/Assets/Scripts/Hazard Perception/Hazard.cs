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

        if (hazardName == "Pan")
        {
            this.transform.rotation = Quaternion.Euler(0, 100, 0);
        }
        else if (hazardName == "Oven Door")
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (hazardName == "Pot")
        {
            this.transform.position = new Vector3(1.837f, 1.152738f, 0.903f);
        }
        else
        {
            this.gameObject.SetActive(false);
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

    public void SetIsHazardFound(bool value)
    {
        isHazardFound = value;
    }
}
