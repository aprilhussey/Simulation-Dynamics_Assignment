using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the movement of the ants - based on Rock Ants
 * (Temnothorax rugatulus).
*/

public class Meander : MonoBehaviour
{
	private Rigidbody2D npcRigidbody;

	[SerializeField] private float speed = 5f;
	[SerializeField] private float npcLength = .01f;

	[SerializeField] private AnimationCurve distribution;

	private Vector2 startPosition;
	private float maxTravelDistance;

	private float randomRotationAngle;

	private bool isTurningLeft;

	void Awake()
	{
		npcRigidbody = GetComponent<Rigidbody2D>();
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
			if (isTurningLeft)
			{
				randomRotationAngle -= GetRandomRotationAngle() * 180;
				this.transform.rotation = Quaternion.Euler(0, 0, randomRotationAngle);
				isTurningLeft = false;

				startPosition = this.transform.position;
			}
			else
			{
				randomRotationAngle += GetRandomRotationAngle() * 180;
				this.transform.rotation = Quaternion.Euler(0, 0, randomRotationAngle);
				isTurningLeft = true;

				startPosition = this.transform.position;
			}
		}
	}

	private void SetFirstTurnDirection()
	{
		float randomDirection = Random.Range(0f, 1f);

		if (randomDirection < 0.5f)
		{
			isTurningLeft = false;
		}
		else
		{
			isTurningLeft = true;
		}
	}

	private float GetRandomRotationAngle()
	{
		float randomRotationAngle = Random.Range(0f, 1f);

		return distribution.Evaluate(randomRotationAngle);
	}
}
