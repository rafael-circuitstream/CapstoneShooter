using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
	[SerializeField]
	private float gravity;
	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<GravitationalBehaviour>(out var gravitationalItem))
			gravitationalItem.currentGravity = gravity;
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<GravitationalBehaviour>(out var gravitationalItem))
			gravitationalItem.currentGravity = SceneGravity.GlobalGravity;
	}
}
