using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove : MonoBehaviour
{
	[SerializeField] private float speed = 0;
	private float barrierXmin = -55f;
	private float barrierXMax = 11f;
	Vector3 mouseLastPos = Vector3.zero;

	 public bool canMove = false;

	[SerializeField] private GameObject[] round; 

	void Update()
	{
		FingerInput();

		if (canMove)
		{
			switch (GameHandler.instance.round)
			{
				case 2:
					if(transform.position.z <= 400)
					{
						GetComponentInChildren<Animator>().Play("CannonBaseSpin");

						if (GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
						{
							transform.Translate(-speed * Time.deltaTime, 0, 0);
							round[0].gameObject.SetActive(false);
						}
					}
					else
					{
						canMove = false;
						GetComponentInChildren<Animator>().Play("CannonBaseSpinBack");

					}

					break;

				case 3:
					if (transform.position.z <= 864)
					{
						GetComponentInChildren<Animator>().Play("CannonBaseSpin");

						if (GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
						{
							transform.Translate(-speed * Time.deltaTime, 0, 0);
							round[1].gameObject.SetActive(false);
						}
					}
					else
					{
						canMove = false;
						GetComponentInChildren<Animator>().Play("CannonBaseSpinBack");

					}
					break;

				default:
					break;		
			}
		}
	}

	private void FingerInput()
	{
		if (Input.touchCount > 0)
		{
			Vector3 fingerPos = Input.touches[0].position;
			fingerPos.z = 200;
			fingerPos = Camera.main.ScreenToWorldPoint(fingerPos);
			if (mouseLastPos == Vector3.zero)
			{
				mouseLastPos = fingerPos;
			}

			fingerPos = new Vector3(fingerPos.x, transform.position.y, transform.position.z);

			MovePlayer(fingerPos);
		}
		else
		{
			mouseLastPos = Vector3.zero;
		}
	}

	public void MovePlayer(Vector3 mousePos) //Moving between the barrierXmin and barrierXMax X positions
	{
		//move diraction
		int dir = 0;
		dir = (mouseLastPos.x < mousePos.x) ? 1 : -1;

		//clamp between min-max
		float xPos = transform.position.x + Mathf.Abs(mouseLastPos.x - mousePos.x) * dir;
		xPos = Mathf.Clamp(xPos, barrierXmin, barrierXMax);
		transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

		mouseLastPos = mousePos;
	}
}
