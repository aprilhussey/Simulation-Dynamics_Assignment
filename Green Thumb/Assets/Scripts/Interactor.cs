using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
	}
}
