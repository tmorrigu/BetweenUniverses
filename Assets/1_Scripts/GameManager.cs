using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour {

	public int test;

	//Puzzle stuff
	public struct PuzzleInfo {
		private string IDtag;
		private string pauseTag;
		private int numHaz;
		public PuzzleInfo(string id, string pause, string hazCount){
			IDtag = id;
			pauseTag = pause;
			numHaz = hazCount;
		}
		public string ID {
			get { return IDtag; }
			set { IDtag = value; }
		}
		public string Pause {
			get { return pauseTag; }
			set{ pauseTag = value; }
		}
		public int HazardCount{
			get{ return numHaz; }
			set{ numHaz = value; }
		}
	}
	private List<PuzzleInfo> puzzleBackgroundData;
	public int currentPuzzleId;
	private GameObject[] tiles;
	public Canvas hint;

	//FIX THIS. Could be a lot cleaner with a slider
	//Starting player health
	private static float MAX_HEALTH = 100f;
	public float playerHealth = MAX_HEALTH;
	private float healthRatio;
	public GameObject healthBar;

	//To track choices in battle
	public int numAttacks;
	public int numRun;

	//For setting up and breaking down battles
	public AudioClip battleStart;
	public GameObject battleParticles;
	public GameObject battleGround;
	public GameObject player;
	public GameObject playerImage;
	[HideInInspector]
	public Text playerText;
	public GameObject mainCam;
	[HideInInspector]
	public Text hazardText;
	//For setting up and breaking down battles
	private GameObject clonePlayer=null;
	[HideInInspector] public GameObject cloneBattle=null;

	public SelectHazard selectHazard;
	private GameObject cloneHazard=null;
	public Hazard cloneHazardStats;
	private float cloneHazardHealth;
	[HideInInspector]
	public bool newBattle = true;

	private Vector3 playerOrigin;
	public GameObject controls;
	public ArrowControls controlScript;

	//Allow other classes to manipulate health/score
	public static GameManager instance = null;

	//Sets up singular instance of GameManager for other classses to use
	void Awake (){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	void Start(){
		numAttacks = 0;
		numRun = 0;
		currentPuzzleId = 0;
		initializePuzzleData ();
	}

	private void initializePuzzleData(){
		//THIS COULD BE BETTER IN CONSISTENCY AND POSSIBLE REUSE OF TAGS
		//Maybe "Puzzle"+ puzzleNumInLevel
		//Get the number of hazards from a separate List, array, etc by puzzleID + puzzleNumInLevel
		puzzleBackgroundData= new List<PuzzleInfo>();
		PuzzleInfo temp = new PuzzleInfo ("PuzzleTileOne", "Pause1", 10);
		puzzleBackgroundData.Add (temp);
		temp = new PuzzleInfo ("PuzzleTileTwo", "Pause2", 30);
		puzzleBackgroundData.Add (temp);
		temp = new PuzzleInfo ("PuzzleTileThree", "Pause3", 40);
		puzzleBackgroundData.Add (temp);
		temp = new PuzzleInfo ("Puzzle4", "Pause4", 50);
		puzzleBackgroundData.Add (temp);
		temp = new PuzzleInfo ("Puzzle5", "Pause5", 50);
		puzzleBackgroundData.Add (temp);
		temp = new PuzzleInfo ("Puzzle6", "Pause6", 50);
		puzzleBackgroundData.Add (temp);
	}

	//Freeze the player, set up battle, start battle
	public void startBattle(){
		player.GetComponent<PlayerController> ().enabled = false;
		player.GetComponent<Footsteps> ().enabled = false;
		if (!controlScript) {
			PlayerController temp = player.GetComponent<PlayerController> ();
			controlScript = temp.arrowcontrol;
			controls = controlScript.gameObject;
		}
		controlScript.Release ();
		controls.SetActive (false);
		Instantiate (battleParticles, player.transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint (battleStart, new Vector3 (mainCam.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z), 0.5f); 
		Invoke("initializeBattle", 2f);
	}

	//Start battle
	public void initializeBattle(){
		if (cloneBattle == null) {
			cloneBattle = Instantiate (battleGround, new Vector3 (0, 50, 0), Quaternion.identity) as GameObject;
			clonePlayer = Instantiate (playerImage, new Vector3 (-4f, 51.5f, 0f), Quaternion.identity) as GameObject;
			cloneHazard = initializeHazard();
			playerText = clonePlayer.GetComponentInChildren<Text> ();
			hazardText = cloneHazard.GetComponentInChildren<Text> ();
		}
	}

	//Set up hazard
	private GameObject initializeHazard(){
		GameObject tempHaz;
		//Temporarily using currentPuzzleId as hazard category, since they'll be linked (though not the same)
		tempHaz = selectHazard.setUpHazard(currentPuzzleId);
		cloneHazardStats = tempHaz.GetComponent<Hazard> ();
		cloneHazardHealth = cloneHazardStats.getHealth ();
		return tempHaz;
	}
		
	//End battle, unfreeze player
	public void endBattle(){
		newBattle = !newBattle;
		if (cloneHazard) {
			Destroy (cloneHazard);
		}
		Destroy (clonePlayer);
		Destroy (cloneBattle);
		controls.SetActive (true);
		player.GetComponent<PlayerController> ().enabled = true;
		player.GetComponent<Footsteps> ().enabled = true;
	}

	//Functions called to reduce health if player/hazard is injured
	public void playerInjury(float lostHealth){
		if (playerText) {
			hazardText.text = "";
			playerText.text = "-" + lostHealth.ToString () + "!";
		}
		playerHealth -= lostHealth;
		healthRatio = (playerHealth / MAX_HEALTH);
		healthBar.GetComponent<RectTransform> ().localScale = new Vector3(healthRatio, healthBar.GetComponent<RectTransform> ().localScale.y, healthBar.GetComponent<RectTransform> ().localScale.z); 
		//Placeholder
		Debug.Log ("Player: " + playerHealth);
		if (playerHealth <= 0f) {
				SceneManager.LoadScene ("Lose_Screen");
		}
	}
	public float hazardInjury(float lostHealth){
		if (hazardText) {
			playerText.text = "";
			hazardText.text = "-" + lostHealth.ToString () + "!";
		}
		cloneHazardHealth -= lostHealth;
		//Placeholder
		Debug.Log ("Hazard: " + cloneHazardHealth);
		if (cloneHazardHealth <= 0f) {
			cloneHazard.SetActive (false);
			clonePlayer.transform.localScale += new Vector3 (1.2f, 1.2f, 1.2f);
			Invoke ("endBattle", 3f);
		}
		return cloneHazardHealth;
	}

	//Functions called to track player choices in battle
	public void playerAttack(){
		numAttacks++;
		Debug.Log ("Attacked: " + numAttacks);
	}
	public void playerRun(){
		numRun++;
		Debug.Log ("Ran: " + numRun);
	}

	public string getTag(int ID){
		return puzzleBackgroundData [ID].ID;
	}

	public string getPauseTag(int ID){
		return puzzleBackgroundData [ID].Pause;
	}

	public int getNumHazards(int ID){
		return puzzleBackgroundData[ID].HazardCount;
	}

	public void enterPuzzle(int ID){
		currentPuzzleId = ID;
		startPuzzles ();
	}

	private void startPuzzles(){
		player.GetComponent<TrackHazard> ().inPuzzle = true;
		PuzzleManagerScript.instance.setUpPuzzle (currentPuzzleId);
		hint.enabled = true;
	}
		
	public void exitPuzzle(){
		player.GetComponent<TrackHazard> ().inPuzzle = false;
		tiles = GameObject.FindGameObjectsWithTag ("PuzzleTile");
		for (int i = 0; i < tiles.Length; i++) {
			tiles [i].tag = puzzleBackgroundData[currentPuzzleId].Pause;
		}
		hint.enabled = false;
	}
}