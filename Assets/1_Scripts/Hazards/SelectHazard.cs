using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SelectHazard : MonoBehaviour {
	//Insectoids
	public GameObject bzzairInsectoid;
	//Mechanoids
	public GameObject eoopMechanoid;
	//Beastoids
	public GameObject griffenBeastoid;
	//Bloboids
	public GameObject companionBloboid;
	//Plantoids
	public GameObject growthPlantoid;
	//Energoids
	public GameObject mmiirEnergoid;
	//Humanoids
	public GameObject zwerokHumanoid;

	private int numInsectoid = 1;
	private int numMechanoid = 1;
	private int numBeastoid = 1;
	private int numBloboid = 1;
	private int numPlantoid = 1;
	private int numEnergoid = 1;
	private int numHumanoid = 1;

	private GameObject temp;
	private Vector3 battlePos = new Vector3 (4f, 51f, 0f);
	private Quaternion battleRot = Quaternion.identity;
	private Dictionary<int, int[]> hazardTypePerCat = new Dictionary<int, int[]>();
	private System.Random rnd = new System.Random ();

	void Start(){
		//The first number is the puzzle ID, the next is an array of hazard types
		hazardTypePerCat.Add(0, new int[]{0,2});
		hazardTypePerCat.Add(1, new int[]{1,2});
		hazardTypePerCat.Add(2, new int[]{2,2});
	}

	public GameObject setUpHazard(int puzzleNum){
		Debug.Log ("setUpHazard, puzzleNum: " + puzzleNum);
		int[] categories;
		GameObject tempHaz=null;
		if (hazardTypePerCat.TryGetValue (puzzleNum, out categories)) {
			if (categories [0] == categories [1]) {
				tempHaz = instantiateHazard (categories [0]);
				Debug.Log ("Same");
			} else {
				tempHaz = instantiateRandomRange (categories [0], categories [1]);
				Debug.Log ("Not Same");
			}
		}else{
			//Error
		}
		return tempHaz;
	}

	public GameObject instantiateHazard(int category){
		Debug.Log ("Category: " + category);
		if (category == 0) {
			//Get Plant
			int random = rnd.Next (0, numPlantoid);
			if (random == 0) {
				temp = Instantiate (growthPlantoid, battlePos, battleRot) as GameObject;
			}else{
				//error
			}
		} else if (category == 1) {
			//Get Insect
			int random = rnd.Next (0, numInsectoid);
			if (random == 0) {
				temp = Instantiate (bzzairInsectoid, battlePos, battleRot) as GameObject;
			}else{
				//error
			}
		} else if (category == 2) {
			//Get Beast
			int random = rnd.Next (0, numBeastoid);
			if (random == 0) {
				temp = Instantiate (griffenBeastoid, battlePos, battleRot) as GameObject;
			}else{
				//error
			}
		} else if (category == 3) {
			//Get Humanoid
			int random = rnd.Next (0, numHumanoid);
			if (random == 0) {
				temp = Instantiate (zwerokHumanoid, battlePos, battleRot) as GameObject;
			}else{
				//error
			}
		} else if (category == 4) {
			//Get Mechanoid
			int random = rnd.Next (0, numMechanoid);
			if (random == 0) {
				temp = Instantiate (eoopMechanoid, battlePos, battleRot) as GameObject;
			}else{
				//error
			}
		} else if (category == 5) {
			//Get Energoid
			int random = rnd.Next (0, numEnergoid);
			if (random == 0) {
				temp = Instantiate (mmiirEnergoid, battlePos, battleRot) as GameObject;
			}else{
				//error
			}
		} else if (category == 6) {
			//Get Blob
			int random = rnd.Next (0, numBloboid);
			if (random == 0) {
				temp = Instantiate (companionBloboid, battlePos, battleRot) as GameObject;
			}else{
				//error
			}
		} else {
			//Error
		}
		return temp;
	}

	public GameObject instantiateRandomRange(int start, int end){
		GameObject tempHaz;
		int random = rnd.Next (start, (end + 1));
		tempHaz = instantiateHazard (random);
		return tempHaz;
	}
}
