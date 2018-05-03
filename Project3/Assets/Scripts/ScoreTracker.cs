using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {
	// The game controller
	public GameController gameController;
	// The text that keeps the score
	public Text scoreText;
	// The numerical value for the score
	public int score = 0;


	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre The score text exists in the game.
	** @post The score is updated.
	** @return None*/
	void Start () {
		updateScore ();
	}
	
	/* @brief Updates after every game frame to increase the score. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	** @pre None
	** @post The game is updated every frame.
	** @return None*/
	void Update () {
		if (gameController.GO()) {
			updateScore ();
		} else {
			score += Mathf.CeilToInt ((Time.time)/10);
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
