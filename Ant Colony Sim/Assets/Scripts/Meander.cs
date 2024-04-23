using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the movement of the ants - based on Rock Ants
 * (Temnothorax rugatulus).
 * -    78% of the time turn one direction then the next
 *      after roughly three times the length of the ant.
 * -    22% of the time is random movement.
*/

public class Meander : MonoBehaviour
{
	private Rigidbody2D npcRigidbody;

	[SerializeField] private float moveSpeed = 0.5f;
	[SerializeField] private float maxMoveDistance = 1f;

	private Vector2 startPosition;
	private float currentMoveDistance;

	private Vector2 moveDirection;

	void Awake()
	{
		npcRigidbody = GetComponent<Rigidbody2D>();

		moveDirection = Random.insideUnitCircle.normalized;
		startPosition = this.transform.position;
		currentMoveDistance = Random.Range(1, maxMoveDistance);

	}

	void Update()
	{
		// Move the NPC
		Vector2 moveVector = moveDirection * moveSpeed * Time.deltaTime;
		npcRigidbody.MovePosition(npcRigidbody.position + moveVector);

		// Make the NPC face the direction it's moving
		float angle = Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg;
		npcRigidbody.rotation = angle;

		// Check if the NPC has moved the maximum distance
		if (Vector2.Distance(startPosition, npcRigidbody.position) > currentMoveDistance)
		{
			// Change direction
			moveDirection = Random.insideUnitCircle.normalized;

			// Reset start position for next direction change
			startPosition = npcRigidbody.position;

			// Randomise the move distance for the next direction change
			currentMoveDistance = Random.Range(1, maxMoveDistance);
		}
	}
}
