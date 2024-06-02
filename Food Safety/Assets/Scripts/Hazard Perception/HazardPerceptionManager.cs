using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HazardPerceptionManager : MonoBehaviour
{
    private Hazard[] hazards;

    [SerializeField]
    private GameObject canvasIntroduction;

    public GameObject popup;
    public TMP_Text txtPopup;

    public GameObject btnReturnToTrainingMenu;

    [TextArea(0, 10)]
    public string txtAllHazardsFound;

    [Header("DebugButtons")]
    public GameObject debugButtons;

    // Input actions
    private PlayerInput playerInput;
    private InputActionAsset inputActionAsset;
    private InputActionMap playerActionMap;

    private void Awake()
    {
        hazards = GameObject.FindObjectsOfType<Hazard>();

        popup.SetActive(false);
        btnReturnToTrainingMenu.SetActive(false);

        // Debug
        debugButtons.SetActive(false);

        // Input actions
        playerInput = GameObject.FindObjectOfType<PlayerInput>();
        inputActionAsset = playerInput.actions;
        playerActionMap = inputActionAsset.FindActionMap("Player");

        inputActionAsset.Enable();

        canvasIntroduction.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (AllHazardsFound())
        {
            Time.timeScale = 0f;

            txtPopup.text = txtAllHazardsFound;
            popup.SetActive(true);

            btnReturnToTrainingMenu.SetActive(true);
        }
    }

    public bool AllHazardsFound()
    {
        foreach (Hazard hazard in hazards)
        {
            if (!hazard.GetIsHazardFound)
            {
                return false;
            }
        }
        return true;
    }

    private void OnEnable()
    {
        playerActionMap["Debug"].performed += OnDebugPerformed;
    }

    private void OnDisable()
    {
        playerActionMap["Debug"].performed -= OnDebugPerformed;
    }

    public void OnStartModuleButtonClick()
    {
        Time.timeScale = 1f;
        canvasIntroduction.SetActive(false);
    }

    // Debug
    private void OnDebugPerformed(InputAction.CallbackContext context)
    {
        if (!debugButtons.activeInHierarchy)
        {
            debugButtons.SetActive(true);
        }
        else
        {
            debugButtons.SetActive(false);
        }
    }

    public void DebugSetAllHazardsToFound()
    {
        foreach (Hazard hazard in hazards)
        {
            hazard.SetIsHazardFound(true);
        }
    }

    public void DebugSetAllHazardsToNotFound()
    {
        foreach (Hazard hazard in hazards)
        {
            hazard.SetIsHazardFound(false);
            hazard.gameObject.SetActive(true);
        }
    }
}
