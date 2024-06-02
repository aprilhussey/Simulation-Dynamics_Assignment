using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HazardPerceptionManager : MonoBehaviour
{
    private Hazard[] hazards;

    public GameObject popup;
    public TMP_Text txtPopup;

    public GameObject btnReturnToTrainingMenu;

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
    }

    private void OnEnable()
    {
        playerActionMap["Debug"].performed += OnDebugPerformed;
    }

    private void OnDisable()
    {
        playerActionMap["Debug"].performed -= OnDebugPerformed;
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

    public GameObject GetPopup
    {
        get { return popup; }
    }
    
    public TMP_Text GetTxtPopup
    {
        get { return txtPopup; } 
    }
}
