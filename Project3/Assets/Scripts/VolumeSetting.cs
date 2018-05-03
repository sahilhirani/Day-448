using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeSetting : MonoBehaviour {
	//the slider for the volume
	public Slider volumeSlider;
	//the sound file for the game music
 	public AudioSource volumeAudio;
	//the volume percentage
	float volume;
	
	/* @brief Controls the in-game volume.
	** @pre None.
	** @post The in-game music volume is changed.
	** @return None*/
 	public void VolumeController(){
    	volume = volumeSlider.value;
		PlayerPrefs.SetFloat("SliderVolumeLevel", volume);
 	}
}