using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinLosMenu : MonoBehaviour {

	//TO be Destroyed
	public GameObject sceneController;
	public GameObject player;
	public GameObject companion;
	public GameObject menus;

	void Awake(){
		sceneController = GameObject.Find ("SceneController");
		player = GameObject.Find ("Player");
		companion = GameObject.Find ("Companion");
		menus = GameObject.Find ("Menus");
		Destroy(player);
		Destroy(companion);
		Destroy(sceneController);
		Destroy(menus);
	}

	public void RestartPress(){
		SceneManager.LoadScene ("Start_Screen");
	}

	public void ExitPress(){
		Application.Quit ();
	}
}
