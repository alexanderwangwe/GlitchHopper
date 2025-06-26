using UnityEngine;
using System.Collections.Generic;

public class BasicRigidBodyPush : MonoBehaviour
{
	public LayerMask pushLayers;
	public bool canPush;
	[Range(0.5f, 5f)] public float strength = 1.1f;

	private List<ControllerColliderHit> hits = new List<ControllerColliderHit>();

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (canPush)
		{
			// Save valid hits to process in FixedUpdate
			if (hit.collider.attachedRigidbody != null && !hit.collider.attachedRigidbody.isKinematic)
			{
				hits.Add(hit);
			}
		}
	}

	private void FixedUpdate()
	{
		foreach (var hit in hits)
		{
			PushRigidBodies(hit);
		}
		hits.Clear(); // Clear after processing
	}

	private void PushRigidBodies(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0) return;

		if (hit.moveDirection.y < -0.3f) return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

		Vector3 newPosition = body.position + pushDir * strength * Time.fixedDeltaTime;
		body.MovePosition(newPosition); // Smooth, stable movement
	}
}
