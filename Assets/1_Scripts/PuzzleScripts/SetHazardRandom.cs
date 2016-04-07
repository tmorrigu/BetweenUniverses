using UnityEngine;
using System.Collections;

public class SetHazardRandom : MonoBehaviour {

	private GameObject[] tiles;
	public int numHazards;

	public void Init (int hazards){
		numHazards = hazards;
		tiles = GameObject.FindGameObjectsWithTag ("PuzzleTile");
		for (int i = 0; i < numHazards; i++) {
			tiles [Random.Range (0, (tiles.Length-1))].tag = "Hazard";
		}
	}
}
