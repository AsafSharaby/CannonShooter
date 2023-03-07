using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private Transform target;
	private Vector3 offset;

	void Start()
	{
		target = FindObjectOfType<CannonMove>().transform;

		offset = transform.position - target.position;
	}

	
	void LateUpdate()
	{
		Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
		transform.position = Vector3.Lerp(transform.position, newPos, 10 * Time.deltaTime);
	}
}
