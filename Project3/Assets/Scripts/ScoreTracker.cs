using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {
	public GameController gameController;
	public Text scoreText;
	public int score = 0;


	// Use this for initialization
	void Start () {
		updateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.GO()) {
			updateScore ();
		} else {
			score += Mathf.CeilToInt ((Time.time)/4);
			updateScore ();
		}
	}

	/* @brief The score on the game screen is updated.
	** @pre None
	** @post Score is updated for the user to see.
	** @return None*/
	public void updateScore() {
		scoreText.text = "SCORE: " + score.ToString();
	}

	/* @brief Increments the score as the user progresses through the game.
	** @pre A valid new score is passed in.
	** @post The score is updated.
	** @return None*/
	public void addScore(int newScoreValue){
		score += newScoreValue;
		updateScore ();
	}
}
