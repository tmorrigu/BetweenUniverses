﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//turn on/off hint
	public Canvas hint;
	//Player movement
	private float speed = 3;
	private Rigidbody rb;
	private bool inPuzzle = true;
	public Collider puzzleGate;
	private bool testPuzzleComplete;
	public ArrowControls arrowcontrol;
	public GameObject errorMessage;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		GameManager.instance.enterPuzzle (0);
		errorMessage.SetActive (false);
	}

	// Called before any Physic's calculations as opposed to Update() which is 
	//     called before each frame, or LateUpdate() which is called at the end.
	//Affects velocity directly, which is bad for realistic physics, but fine 
	//		for this, since the 3rd person camera just hovers above.
	void FixedUpdate() 
	{
		Vector3 move;
		float h;
		float v;

		//if (mobile?????){
			h = arrowcontrol.ArrowInput.x;
			v = arrowcontrol.ArrowInput.y;
/*		} else {
			h = Input.GetAxis ("Horizontal");
			v = Input.GetAxis ("Vertical");
		}  */

		move = (v*Vector3.forward) + (h*Vector3.right);
		move.x *= speed;
		move.z *= speed;
		rb.velocity = new Vector3(move.x,rb.velocity.y,move.z);
	}

	//This is puzzle stuff. Can it be separated to not call outside the puzzle?
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PuzzleOne")) {
			inPuzzle = true;
			puzzleGate = other;
			GameManager.instance.enterPuzzle (0);
		} else if (other.gameObject.CompareTag ("PuzzleTwo")) {
			inPuzzle = true;
			puzzleGate = other;
			GameManager.instance.enterPuzzle (1);
		} else if (other.gameObject.CompareTag ("PuzzleThree")) {
			inPuzzle = true;
			puzzleGate = other;
			GameManager.instance.enterPuzzle (2);
		} else if (other.gameObject.CompareTag ("TriggerExit")) {
			inPuzzle = false;
			GameManager.instance.exitPuzzle ();
		} else if (other.gameObject.CompareTag ("TriggerFinish")) {
			testPuzzleComplete = PuzzleManagerScript.instance.checkExit ();
			if (testPuzzleComplete) {
				puzzleGate.isTrigger = true;
			} else {
				if (inPuzzle) {
					//Need to test if this is the first time the player has moved into the puzzle,
					//But this is updated in the enter trigger, not the exit trigger
					//So it will always show false
					//NEED TO FIX!!!
					errorMessage.SetActive (true);
				}
				puzzleGate.isTrigger = false;
			}
		} else if (other.gameObject.CompareTag ("PuzzleTile")) {
			PuzzleManagerScript.instance.changeMat (other);
			other.gameObject.tag = "finishedTile";
		} else if (other.gameObject.CompareTag ("Hazard")) {
			PuzzleManagerScript.instance.encounterHazard (other);
			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			if (GameManager.instance.cloneBattle == null) {
				GameManager.instance.startBattle (); 
				other.gameObject.tag = "finishedHazard";
			} else {
				//Add functionality for two at once
			}
		}  else if (other.gameObject.CompareTag ("LevelTwo")) {
			hint.enabled = false;
			SceneManager.LoadScene ("1_LevelTwo");
			gameObject.transform.position = new Vector3 (0f, 0f, 0f);
		} else if (other.gameObject.CompareTag ("win")) {
			SceneManager.LoadScene ("Win_Screen");
		} else if (other.gameObject.CompareTag ("lose")) {
			SceneManager.LoadScene ("Lose_Screen");
		}
	}

	//To pick up items
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("TreasureChest")) {
			col.gameObject.GetComponent<Animation> ().Play ();
			Debug.Log ("Coins +100000000");
		} 
		else if (col.gameObject.CompareTag ("Potion")) {
			Debug.Log ("Potion +1");
			Destroy(col.gameObject, 0.5f);
		}
	}

	public void TurnOffError(){
		errorMessage.SetActive (false);
	}
}