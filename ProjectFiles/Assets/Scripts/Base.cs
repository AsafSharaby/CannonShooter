using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
	[SerializeField] private Text healthText;
	[SerializeField] private int healthNum;
	[SerializeField] private GameObject explotipn_VFX;

	void Start()
    {
		healthText.text = healthNum.ToString();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Mob"))
		{
			healthNum--;
			GameHandler.instance.GetScore(1);
			Destroy(other.gameObject);

			healthText.text = healthNum.ToString();

			if(healthNum <= 0)
			{
				foreach (var item in FindObjectsOfType<Mob>())
				{
					Destroy(item.gameObject);
				}

				Instantiate(explotipn_VFX, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z ), Quaternion.identity);

				GameHandler.instance.NextRound();
				Destroy(gameObject);
			}
		}
	}
}
