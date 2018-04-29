using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
	public Text scoreText;
	//text that holds the "Game Over" message
	public Text gameOverText;
	//text that holds the option to restart the game
	public Text restartText;
	//the players score
	public int score;
	//value that determines if player resarts
	private bool restart;
	//value that determines if game is over
	public bool gameOver;
	//asteroidSpawner aS;

	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre The game objects are valid and the game is prepared to be run.
	** @post Score count is started and the game begins spawning asteroids.
	** @return None*/
	void Start() {
		restart = false;
		gameOver = false;
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		updateScore ();


	}

	/* @brief Updates after every game frame to create asteroids for the user to dodge/shoot. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	** @pre None
	** @post The game is updated every frame.
	** @return None*/
	void Update(){
		//checks to see if the user has selected to restart the game
		if (gameOver) {
			updateScore ();
		} else {
			score += Mathf.CeilToInt (Time.time);
			updateScore ();
		}
		if (restart) {
			//if user has pressed "R" the game restarts
			if (Input.GetKeyDown (KeyCode.R)) {
				//game restarts
				SceneManager.LoadScene("Main");
			} 
			//if user has pressed "M" the game goes to the menu
			else if (Input.GetKeyDown (KeyCode.M)) {
				//scence changes to menu
				SceneManager.LoadScene ("MainMenu UI");
			}
		}

	}


	/* @brief Increments the score as the user progresses through the game.
	** @pre A valid new score is passed in.
	** @post The score is updated.
	** @return None*/
	public void addScore(int newScoreValue){
		score += newScoreValue;
		updateScore ();
	}

	/* @brief The score on the game screen is updated.
	** @pre None
	** @post Score is updated for the user to see.
	** @return None*/
	public void updateScore() {
		scoreText.text = "SCORE: " + score.ToString();
	}

	/* @brief Displays the "Game Over" text after the user's ship is destroyed.
	** @pre None
	** @post The user is notified that the game is over and they are able to view their final score.
	** @return None*/
	public void GameOver(){
		gameOverText.text = "Game Over!";
		gameOver = true;
		restart = true;
		restartText.text = "To Restart press 'R' or Press 'M' to go to the Main Menu";
		scoreText.text = "";
	}

	public bool GO(){
		if (gameOver) {
			return true;
		} else {
			return false;
		}
	}

}
