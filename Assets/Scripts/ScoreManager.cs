using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score;
	public Text key;
	public Text highScore1;
	public Text highScore2;
	public Text CountDownText;
	public Text displayCountDown;
	public float scoreCount;
	public float keyCount;
	public float highScore1Count;
	public float highScore2Count;

	private float CountDown = 60;
	private PlayerController player;

	void Start () 
	{
		player = FindObjectOfType<PlayerController> ();
		SetStarCount ();
		scoreCount = 0;
		SetKeyCount ();

		if (PlayerPrefs.HasKey ("High Score")) 
		{
			highScore1Count = PlayerPrefs.GetFloat ("High Score");
			highScore2Count = PlayerPrefs.GetFloat ("High Score");
		}
	}
	

	void Update () 
	{
		if (scoreCount > highScore1Count) 
		{
			highScore1Count = scoreCount;
			PlayerPrefs.SetFloat ("High Score",highScore1Count);
		}

		if (scoreCount > highScore2Count) 
		{
			highScore2Count = scoreCount;
			PlayerPrefs.SetFloat ("High Score",highScore2Count);
		}

		if (CountDown > 0) 
		{
			CountDown -= Time.deltaTime; 
			CountDownText.text = "Time: " + CountDownText.ToString();
			displayCountDown.text = CountDown.ToString ("F0");
		} 
		if (CountDown <= 0) 
		{ 
			player.gameOverPanel.SetActive (true);
			this.enabled = false;
			Destroy (gameObject);

		} 

		score.text = "Score: " + Mathf.Round (scoreCount);
		highScore1.text = "High Score: " + Mathf.Round (highScore1Count);
		highScore2.text = "High Score: " + Mathf.Round (highScore2Count);
	}

	public void SetStarCount ()
	{
		score.text = "Score: " + scoreCount.ToString ();
	}

	public void SetKeyCount ()
	{
		key.text = "Keys: " + keyCount.ToString ();
	}
}
