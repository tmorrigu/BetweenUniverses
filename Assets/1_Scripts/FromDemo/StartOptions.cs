using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartOptions : MonoBehaviour {



	public int sceneToStart = 1;										//Index number in build settings of scene to load if changeScenes is true
	public bool changeMusicOnStart;										//Choose whether to continue playing menu music or start a new music clip
	public int musicToChangeTo = 0;										//Array index in array MusicClips to change to if changeMusicOnStart is true.
	public PlayMusic playMusic;										//Reference to PlayMusic script
	public Animator animColorFade; 					//Reference to animator which will fade to and from black when starting game.
	public AnimationClip fadeColorAnimationClip;		//Animation clip fading to color (black default) when changing scenes

//	private float fastFadeIn = .01f;									//Very short fade time (10 milliseconds) to start playing music immediately without a click/glitch
	private float slowFadeIn = .9f;
	public bool showVid = true;

	public void videoToggle(){
		showVid = !showVid;
	}

	public void StartButtonClicked()
	{
		//If changeMusicOnStart is true, fade out volume of music group of AudioMixer by calling FadeDown function of PlayMusic, using length of fadeColorAnimationClip as time. 
		//To change fade time, change length of animation "FadeToColor"
		if (changeMusicOnStart) 
		{
			playMusic.FadeDown(fadeColorAnimationClip.length);
			Invoke ("PlayNewMusic", fadeColorAnimationClip.length);
		}

		//Start fading and change scenes halfway through animation when screen is blocked by FadeImage
		//Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
		Invoke ("LoadDelayed", fadeColorAnimationClip.length * .5f);
		//Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
		animColorFade.SetTrigger ("fade");
	}


	public void LoadDelayed()
	{
		if (showVid) {
			SceneManager.LoadScene ("Start_Video");
		} else if (!showVid) {
			SceneManager.LoadScene ("0_Start");
		} else {
			Debug.Log ("showVid broken" + showVid);
		}
		//Load the selected scene, by scene index number in build settings
	//	SceneManager.LoadScene(sceneToStart);
//		Application.LoadLevel (sceneToStart);
	}

	public void PlayNewMusic()
	{
		//Fade up music nearly instantly without a click 
		playMusic.FadeUp (slowFadeIn);
		//Play music clip assigned to mainMusic in PlayMusic script
		playMusic.PlaySelectedMusic (musicToChangeTo);
	}
}
