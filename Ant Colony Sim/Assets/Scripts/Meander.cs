using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Handles the movement of the ants - based on Rock Ants
 * (Temnothorax rugatulus).
*/

public class Meander : MonoBehaviour
{
	private Rigidbody2D npcRigidbody;
	private float npcLength;

	[SerializeField] private float speed = 5f;
	[SerializeField] private AnimationCurve distribution;

	private Vector2 startPosition;
	private float maxTravelDistance;

	private float randomRotationAngle;

	private bool turnLeft;

	void Awake()
	{
		npcRigidbody = GetComponent<Rigidbody2D>();

		// Calculate length of NPC
		CalculateNPCLength();

		// Set max travel distance of NPC
		maxTravelDistance = 3 * npcLength;
	}

	void Start()
	{
		startPosition = this.transform.position;

		// Set random rotation angle
		randomRotationAngle = Random.Range(-180, 180f);
		this.transform.rotation = Quaternion.Euler(0, 0, randomRotationAngle);

		// Set direction NPC will turn first
		SetFirstTurnDirection();
	}

	void Update()
	{
		// Move NPC in the direction they are facing
		Vector2 forward = new Vector2(this.transform.up.x, this.transform.up.y);
		npcRigidbody.velocity = forward * speed;

		if (Vector2.Distance(npcRigidbody.position, startPosition) >= maxTravelDistance)
		{
			if (turnLeft)
			{
				randomRotationAngle -= GetRandomRotationAngle() * 180;
				this.transform.rotation = Quaternion.Euler(0, 0, randomRotationAngle);
				turnLeft = false;

				// Reset start position
				startPosition = this.transform.position;
			}
			else	// Turn right
			{
				randomRotationAngle += GetRandomRotationAngle() * 180;
				this.transform.rotation = Quaternion.Euler(0, 0, randomRotationAngle);
				turnLeft = true;

				// Reset start position
				startPosition = this.transform.position;
			}
		}

		DetectObstacle();
	}

	private void SetFirstTurnDirection()
	{
		float randomDirection = Random.Range(0f, 1f);

		if (randomDirection < 0.5f)
		{
			turnLeft = false;
		}
		else
		{
			turnLeft = true;
		}
	}

	private float GetRandomRotationAngle()
	{
		float randomRotationAngle = Random.Range(0f, 1f);

		return distribution.Evaluate(randomRotationAngle);
	}

	private void CalculateNPCLength()
	{
		Renderer renderer = this.GetComponentInChildren<Renderer>();

		if (renderer != null)
		{
			npcLength = renderer.bounds.size.y;
		}
		else
		{
			Debug.Log($"No renderer found on: {this.gameObject.name}");
		}
	}

	private void DetectObstacle()
	{
		// Define starting point and direction of ray
		Vector2 rayOrigin = this.transform.position;
		Vector2 rayDirection = this.transform.up;

		// Define length of ray
		float rayLength = 10f;

		// Perform raycast
		RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayLength);

		// Check if raycast hit obstacle
		if (hit.collider != null)
		{
			if (hit.collider.gameObject.transform.parent != null && hit.collider.gameObject.transform.parent.CompareTag("Obstacle"))
			{
				Debug.Log($"Obstacle detected: {hit.collider.gameObject.transform.parent.name}");
			}
		}
	}
}
