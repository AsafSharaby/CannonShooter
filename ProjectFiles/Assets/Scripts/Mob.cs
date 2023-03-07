using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
	private NavMeshAgent agent;
	public Transform target;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();

		target = GameHandler.instance.GetTarget();
	}

	void Update()
	{
		agent.destination = target.position;
	}
}
