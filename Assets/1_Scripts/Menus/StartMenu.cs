using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Canvas howTo;
	public Canvas story;
	public Canvas optionsMenu; 

	public Button newButton;
	public Button optionsButton;
	public Button howToButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
		howTo.enabled = false;
		story.enabled = false;
		optionsMenu.enabled = false;
	}

	public void NewPress(){
		SceneManager.LoadScene ("0_Start");
	}

	public void OptionsPress(){
		optionsMenu.enabled = true;
		newButton.enabled = false;
		optionsButton.enabled = false;
		howToButton.enabled = false;
		exitButton.enabled = false;
	}

	public void HowToPress(){
		story.enabled = true;
		newButton.enabled = false;
		optionsButton.enabled = false;
		howToButton.enabled = false;
		exitButton.enabled = false;
	}

	public void StoryToHow(){
		story.enabled = false;
		howTo.enabled = true;
	}

	public void HowToStory(){
		story.enabled = true;
		howTo.enabled = false;
	}
		
	public void ExitPress(){
		Application.Quit ();
	}

	public void BackPress(){
		howTo.enabled = false;
		story.enabled = false;
		optionsMenu.enabled = false;
		newButton.enabled = true;
		optionsButton.enabled = true;
		howToButton.enabled = true;
		exitButton.enabled = true;
	}
}