using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//To Destroy
	public GameObject sceneController;
	public GameObject player;
	public GameObject companion;
	public GameObject menus;
	public GameObject puzzleManager;

	public Canvas mainMenu;
	public Canvas optionsMenu;
	public Button menuButton;
	public Button newButton;
	public Button continueButton;
	public Button optionsButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
		mainMenu.enabled = false;
		optionsMenu.enabled = false;
	}

	public void MenuPress(){
		mainMenu.enabled = true;
		menuButton.enabled = false;
	}

	public void NewPress(){
		Destroy(sceneController);
		Destroy(player);
		Destroy(companion);
		Destroy(menus);
		PuzzleManagerScript.instance.Start();
		SceneManager.LoadScene ("Start_Screen");
	}

	public void ContinuePress(){
		menuButton.enabled = true;
		mainMenu.enabled = false;
	}

	public void OptionsPress(){
		mainMenu.enabled = false;
		optionsMenu.enabled = true;
	}

/*	public void ExitPress(){
		Application.Quit ();
	}
*/
	public void OptionsBackPress(){
		mainMenu.enabled = true;
		optionsMenu.enabled = false;
	}
}