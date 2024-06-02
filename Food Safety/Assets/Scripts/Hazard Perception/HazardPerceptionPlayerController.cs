using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HazardPerceptionPlayerController : MonoBehaviour
{
    private Camera mainCamera;

    // Input actions
    private PlayerInput playerInput;
    private InputActionAsset inputActionAsset;
    private InputActionMap playerActionMap;

    private Vector2 screenPosition;

    public GameObject popup;
    public TMP_Text txtPopup;

    private void Awake()
    {
        mainCamera = Camera.main;

        // Input actions
        playerInput = this.GetComponent<PlayerInput>();
        inputActionAsset = playerInput.actions;
        playerActionMap = inputActionAsset.FindActionMap("Player");

        inputActionAsset.Enable();
    }

    private void OnEnable()
    {
        playerActionMap["Click"].performed += OnClickPerformed;

        playerActionMap["ScreenPosition"].performed += context => { screenPosition = context.ReadValue<Vector2>(); };
    }

    private void OnDisable()
    {
        playerActionMap["Click"].performed -= OnClickPerformed;
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<Hazard>() != null && !hit.transform.GetComponent<Hazard>().GetIsHazardFound)
            {
                Hazard hazard = hit.transform.GetComponent<Hazard>();
                hazard.ClickedAction();

                txtPopup.text = hazard.GetHazardClickedDescription;
                StartCoroutine(ShowAndHidePopup());
            }
        }
    }

    private IEnumerator ShowAndHidePopup()
    {
        popup.SetActive(true);

        yield return new WaitForSeconds(5f);

        popup.SetActive(false);
    }
}
