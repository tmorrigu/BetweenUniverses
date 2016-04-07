using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuzzleManagerScript : MonoBehaviour {

	public struct Puzzle {
		private int numSafe;
		private int numBattle;

		public Puzzle(int s, int b) {
			numSafe = s;
			numBattle = b;
		}
		public int Safe {
			get { return numSafe; }
			set { numSafe = value; }
		}
		public int Battle {
			get { return numBattle; }
			set { numBattle = value; }
		}
	}

	//Allow other classes to manipulate health/score
	public static PuzzleManagerScript instance = null;

	private GameObject[] reset;
	private GameObject[] tiles;
	private SetHazardRandom script;
	private string puzzleTag;
	private string pauseTag;
	private int numHazards;
	//Only set up if it's the first time
	private bool[] newPuzzle;
	//For puzzle changes
	public Material safeMat;
	public Material hazardMat;
	//Track how many of each squares have been encountered.
	[HideInInspector] public int safeCount;
	[HideInInspector] public int battleCount;
	private int currentPuzzle;
	public Text errorText;

	private Puzzle PuzzleOne, PuzzleTwo, PuzzleThree;

	//Sets up singular instance of GameManager for other classses to use
	void Awake (){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}
		
	// Use this for initialization
	public void Start () {
		script = gameObject.AddComponent<SetHazardRandom>();
		newPuzzle = new bool[] {true,true,true,true,true,true};
		PuzzleOne = new Puzzle(0,0);
		PuzzleTwo = new Puzzle(0,0);
		PuzzleThree = new Puzzle(0,0);
	}

	public void setUpPuzzle(int puzzleNum){
		if (newPuzzle [puzzleNum]) {
			puzzleTag = GameManager.instance.getTag (puzzleNum);
			reset = GameObject.FindGameObjectsWithTag (puzzleTag);
			for (int i = 0; i < reset.Length; i++) {
				reset [i].tag = "PuzzleTile";
			}
			numHazards = GameManager.instance.getNumHazards (puzzleNum);
			script.Init (numHazards);
			newPuzzle [puzzleNum] = false;
		} else {
			pauseTag = GameManager.instance.getPauseTag (puzzleNum);
			tiles = GameObject.FindGameObjectsWithTag (pauseTag);
			for (int i = 0; i < tiles.Length; i++) {
				tiles [i].tag = "PuzzleTile";
			}
		}
		currentPuzzle = puzzleNum;
	}

	private void incrementSafe(){
		switch (currentPuzzle) {
		case 0: 
			PuzzleOne.Safe++;
			break;
		case 1:
			PuzzleTwo.Safe++;
			break;
		case 2:
			PuzzleThree.Safe++;
			break;
		default:
			break;
		}
	}

	private void incrementBattle(){
		switch (currentPuzzle) {
		case 0: 
			PuzzleOne.Battle++;
			break;
		case 1:
			PuzzleTwo.Battle++;
			break;
		case 2:
			PuzzleThree.Battle++;
			break;
		default:
			break;
		}
	}

	public bool checkExit(){
		//check puzzle completion goals
		int ID;
		ID = GameManager.instance.currentPuzzleId;
		if (ID == 0) {
			return checkOne ();
		} else if (ID == 1) {
			return checkTwo ();
		} else if (ID == 2) {
			return checkThree ();
		} else {
			return false;
		}
	}

	//check completion of minimum puzzle goals
	private bool checkOne(){
		if (PuzzleOne.Safe > 50) {
			return true;
		} else {
			if (errorText.IsActive ()) {
				updateText (50, PuzzleOne.Safe);
			}
			return false;
		}
	}

	private bool checkTwo(){
		if (PuzzleTwo.Safe > 80) {
			return true;
		} else {
			if (errorText.IsActive ()) {
				updateText (80, PuzzleTwo.Safe);
			}
			return false;
		}
	}

	private bool checkThree(){
		if (PuzzleThree.Safe > 80) {
			return true;
		} else {
			if (errorText.IsActive()) {
				updateText (80, PuzzleThree.Safe);
			}
			return false;
		}
	}

	private void updateText(int total, int done){
		errorText.text = "You have cleared " + done + " squares. You must clear " + total + " squares!";
	}

	public void changeMat(Collider other){
		other.GetComponent<Renderer> ().material.CopyPropertiesFromMaterial (safeMat);
		other.gameObject.tag = "finishedTile";
		incrementSafe ();
		safeCount++;
	}

	public void encounterHazard(Collider other){
		other.GetComponent<Renderer> ().material.CopyPropertiesFromMaterial (hazardMat);
		incrementBattle ();
		battleCount++;
	}
}
