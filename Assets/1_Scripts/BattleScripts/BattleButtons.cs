using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleButtons : MonoBehaviour {

	public Text playerUpdates;
	public Text hazardUpdates;
	public GameObject killBattleScript;
	public Button attack;
	public Button run;

	private float hazardHealthLocal;
	private int hazardDefense;
	private int hazardStrength;
	private float baseAttack = 10f;
	private float trueAttack;
	private float baseDefend = 5f;
	private float trueDefend;
	private bool hazIsDefending = false;

	private int hazardAgro;
	private int hazardFear;
	private float attackCap;
	private float defendCap;
	private float runCap;

	private List<string> options;
	private int numChoices;

	public void newHazard(){
		hazardDefense = GameManager.instance.cloneHazardStats.getDefense ();
		hazardStrength = GameManager.instance.cloneHazardStats.getStrength ();
		hazardAgro = GameManager.instance.cloneHazardStats.getAgression ();
		hazardFear = GameManager.instance.cloneHazardStats.getFearfulness ();
		options = GameManager.instance.cloneHazardStats.getOtherActions ();
		numChoices = options.Count;

		attackCap = (float)(25 + (10 * (hazardAgro - 3)));
		defendCap = (float)(attackCap + (25 - (10 * (hazardAgro - 3))));
		runCap = (float)(defendCap + (15 + (5 * (hazardFear - 3))));
		trueAttack = baseAttack + hazardStrength;
		trueDefend = baseDefend + hazardDefense;
	}

	private void hazardTurn(){
		if (GameManager.instance.newBattle) {
			newHazard ();
			GameManager.instance.newBattle = false;
		}
		hazIsDefending = false;
		float choice = Random.Range (0, 100);
		if (choice < attackCap) {
			hazardAttack();
		} else if (choice < defendCap) {
			hazardDefend ();
		} else if (choice < runCap) {
			hazardRun ();
		} else {
			hazardOther ();
		}
	}

	private void hazardAttack(){
		hazardUpdates.text = "Hazard Attacks!";
		GameManager.instance.playerInjury (trueAttack);
		attack.enabled = true;
		run.enabled = true;
	}
	private void hazardDefend(){
		hazardUpdates.text = "Hazard Raises Their Defenses!";
		hazIsDefending = true;
		attack.enabled = true;
		run.enabled = true;
	}
	private void hazardRun(){
		hazardUpdates.text = "Hazard Ran Away!";
		killBattleScript.SetActive (true);
	}
	private void hazardOther(){
		int choice = Random.Range (0, (numChoices - 1));
		if (numChoices >= 0) {
			string action = options [choice];
			hazardUpdates.text = action;
		} else {
			hazardUpdates.text = "Oops...";
		}
		Debug.Log ("Num Choices: " + numChoices + " Choice: " + choice);
		attack.enabled = true;
		run.enabled = true;
	}

	public void playerAttackButton(){
		float attackDamage = 10f;
		GameManager.instance.playerAttack ();
		playerUpdates.text = "Attack the hazard!";
		hazardUpdates.text = "...";
		if (hazIsDefending) {
			attackDamage -= trueDefend;
		}
		hazardHealthLocal = GameManager.instance.hazardInjury (attackDamage);
		if (hazardHealthLocal > 0f) {
			Invoke ("hazardTurn", 1.5f);
			attack.enabled = false;
			run.enabled = false;
		} else {
			hazardUpdates.text = "hazard died...";
		}
	}

	public void playerRunButton(){
		GameManager.instance.playerRun ();
		int success = Random.Range (0, 2);
		if (success < 1) {
			playerUpdates.text = "Ran away!";
			hazardUpdates.text = "...";
			attack.enabled = false;
			run.enabled = false;
			killBattleScript.SetActive (true);
//			GameManager.instance.endBattle ();
		} else {
			playerUpdates.text = "Failed to get away!";
			hazardUpdates.text = "...";
			attack.enabled = false;
			run.enabled = false;
			Invoke ("hazardTurn", 1.5f);
		}
	}
}
