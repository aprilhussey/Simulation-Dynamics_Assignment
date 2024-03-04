using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private Transform interactionPoint;
    [SerializeField]
    private float interactionPointRadius = 0.5f;
    [SerializeField]
    private LayerMask interactableMask;

    private readonly Collider[] colliders = new Collider[3];
    
    [SerializeField]
    private int interactablesFound;

    void Update()
    {
        interactablesFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
	}

	public void OnInteract(InputAction.CallbackContext context)
	{
		if (!context.performed) return; // Ensure action only happens once

		if (interactablesFound > 0)
		{
			IInteractable interactable = colliders[0].GetComponent<IInteractable>();
			interactable.Interact(this);
		}
	}

	public void OnGetKnowledge(InputAction.CallbackContext context)
	{
		if (!context.performed) return; // Ensure action only happens once

		if (interactablesFound > 0)
		{
			IInteractable interactable = colliders[0].GetComponent<IInteractable>();
			interactable.GetKnowledge();
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
	}
}
