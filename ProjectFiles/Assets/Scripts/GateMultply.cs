using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateMultply : MonoBehaviour
{
	public GateType type;


	[SerializeField] private int num;
	
	[SerializeField] private int curSpeed = 7;
	[SerializeField] private bool IsMoving = false;
	private int speedAmount =0;

	[SerializeField] private Text numText;
 
	private void Start()
	{
		speedAmount = curSpeed;

		if (type == GateType.Rag)
			numText.text = "X" + num;
	}
	void Update()
	{
		if (IsMoving)
		{
			if (transform.position.x <= -50f)
				speedAmount = -curSpeed;
			else if (transform.position.x >= 7.5f)
				speedAmount = curSpeed;

			transform.Translate(0, speedAmount * Time.deltaTime, 0);
		}
	}

	private void MultipleObj(int num,Collider collider)
	{
		for (int i = 0; i < num; i++)
		{
			GameObject temp = Instantiate(collider.gameObject, new Vector3(transform.position.x,transform.position.y,transform.position.z+10), Quaternion.identity);
		}
	}


	private void OnTriggerExit(Collider other)
	{
		if(type == GateType.Rag)
		{
			if (other.gameObject.CompareTag("Mob"))
			{
				MultipleObj(num, other);
			}
		}
		else
		{
			if (other.gameObject.CompareTag("Mob"))
			{
				Destroy(other.gameObject);
			}
		}
		
	}
}

public enum GateType
{
	Rag,
	Killer
}
