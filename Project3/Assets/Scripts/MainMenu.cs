using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	/* @brief Loads the menu for the player to select difficulty
	** @pre A valid game scene exists.
	** @post The player chooses their desired difficulty.
	** @return None*/
	public void Play(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	/* @brief Loads the easy mode of the game.
	** @pre A valid game scene exists.
	** @post The player starts playing the game.
	** @return None*/
	public void Easy(){
		SceneManager.LoadScene ("Easy");
	}

	/* @brief Loads the regular mode of the game.
	** @pre A valid game scene exists.
	** @post The player starts playing the game.
	** @return None*/
	public void Regular(){
		SceneManager.LoadScene ("Regular");
	}

	/* @brief Loads the hard mode for the game.
	** @pre A valid game scene exists.
	** @post The player starts playing the game.
	** @return None*/
	public void Insane(){
		SceneManager.LoadScene ("Insane");
	}

    /* @brief Loads the scene where the test is.
	** @pre A valid test scene exists.
	** @post The player starts testing the game.
	** @return None*/
    public void Test()
    {
		SceneManager.LoadScene ("Test");
    }

    /* @brief Displays the how to play screen.
	** @pre None
	** @post None
	** @return None*/
    public void HowTo(){

	}
}
