using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
	[SerializeField] private GameObject mobPrefab;
	[SerializeField] private Transform point;
	
	[SerializeField] private float fireRate = 1;


	private float nextFire = 0;

	private void Update()
	{
		if (Input.touchCount > 0 && Time.time >nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(mobPrefab, point.position, Quaternion.identity);
		}
	}
}
