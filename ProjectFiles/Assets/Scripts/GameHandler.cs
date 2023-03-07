using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
	public static GameHandler instance;


	[SerializeField] private Transform[] bases;
	[SerializeField] private Text scoreText;
	[SerializeField] private Text roundText;
	public Transform target;
	public int round = 1;
	private int score = 0;

	[SerializeField] private GameObject roundPanel;
	[SerializeField] private Image[] roundFilledImages;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		scoreText.text = score.ToString();
		roundText.text = "ROUND" + round.ToString() + "/3";
		GameRound();
	}

	public Transform GetTarget()
	{
		return target;
	}

	private void GameRound()
	{
		switch (round)
		{
			case 1:
				target = bases[0];
				break;

			case 2:
				target = bases[1];
				break;

			case 3:
				target = bases[2];
				break;

			default:
				break;
		}
	}

	public void NextRound()
	{
		RoundImage();
		roundText.text = "ROUND" + round.ToString() + "/3";
		round++;
		FindObjectOfType<CannonMove>().canMove = true;
		GameRound();
		StartCoroutine(SetRoundPanelFalse());
	}

	public void GetScore(int num)
	{
		score += num;
		scoreText.text = score.ToString();
	}

	public void RoundImage()
	{
		roundPanel.SetActive(true);

		switch (round)
		{
			case 1:
				roundFilledImages[0].GetComponent<Animator>().Play("roundFIlledImage1");
					break;

			case 2:
				roundFilledImages[1].GetComponent<Animator>().Play("roundFIlledImage1");
				break;

			case 3:
				roundFilledImages[2].GetComponent<Animator>().Play("roundFIlledImage1");
				break;

			default:
				break;
		}
	}


	IEnumerator SetRoundPanelFalse()
	{
		yield return new WaitForSeconds(3);

		roundPanel.SetActive(false);
	}
}
