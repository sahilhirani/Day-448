using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	/* @brief Loads the scene where the actual game is.
	** @pre A valid game scene exists.
	** @post The player starts playing the game.
	** @return None*/
	public void Play(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	/* @brief Displays the how to play screen.
	** @pre None
	** @post None
	** @return None*/
	public void HowTo(){

	}
}
