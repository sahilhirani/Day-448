using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeSetting : MonoBehaviour {
	public Slider volumeSlider;
 	public AudioSource volumeAudio;
	float volume;
	
 	public void VolumeController(){
    	volume = volumeSlider.value;
		PlayerPrefs.SetFloat("SliderVolumeLevel", volume);
 	}
}