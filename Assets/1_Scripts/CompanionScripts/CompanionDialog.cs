using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompanionDialog : MonoBehaviour {

	private bool first;
	private CompanionMovement cm;
	private Text companionText;
	private Button yes;
	private Button no;
	private Button ok;
	private Button[] options;

	public Canvas dialogCanvas;

	void Awake(){
		cm = gameObject.GetComponent<CompanionMovement> ();
		if (!companionText) {
			companionText = dialogCanvas.GetComponentInChildren<Text> ();
		}
	}

	void Start(){
		dialogCanvas.enabled = false;
		options = dialogCanvas.GetComponentsInChildren<Button> ();
		foreach (Button choice in options){
			if (choice.CompareTag ("yes")) {
				yes = choice;
			} else if (choice.CompareTag ("no")) {
				no = choice;
			} else if (choice.CompareTag("ok")){
				ok = choice;
			}
		}
	}

	
	public void startRunning (){
		Scene temp = SceneManager.GetActiveScene ();
		if (temp.name == "0_Start") {
			first = true;
		} else {
			cm.startRunning ();
		}
		if (first) {
			first = false;
			dialogCanvas.enabled = true;
			yes.gameObject.SetActive (false);
			no.gameObject.SetActive (false);
			if (ok) {
				ok.gameObject.SetActive (false);
				companionDecide ();
			} else {
				HangOut ();
			}
		}
	}

	private void companionDecide(){
		companionText = dialogCanvas.GetComponentInChildren<Text> ();
		if (GameManager.instance.numAttacks > GameManager.instance.numRun) {
			companionText.text = "You are a jerk.";
			ok.gameObject.SetActive (true);
		} else {
			HangOut ();
		}
	}

	private void HangOut(){
		companionText.text = "Want to hang out?";
		yes.gameObject.SetActive (true);
		no.gameObject.SetActive (true);
	}

	public void optionYes(){
		dialogCanvas.enabled = false;
		cm.startRunning ();
	}

	public void optionNo(){
		dialogCanvas.enabled = false;
	}

	public void optionOk(){
		dialogCanvas.enabled = false;
	}

}
