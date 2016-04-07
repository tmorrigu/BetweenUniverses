using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TrackHazard : MonoBehaviour {

	private Vector3 center;
	private Collider[] collidersInRange;
	static private float radius = 1.0f;
	public Outline alert;
	public Text numHazOut;
	public bool inPuzzle = true;

	// Update is called once per frame
	void LateUpdate () {
		if (inPuzzle) {
			center = gameObject.transform.position;
			collidersInRange = Physics.OverlapSphere (center, radius);
			int i = 0;
			int numHazards = 0;
			while (i < collidersInRange.Length) {
				if (collidersInRange [i].CompareTag ("Hazard")) {
					numHazards++;
				}
				i++;
			} 
			if ((Input.anyKeyDown)||(Input.anyKey)) {
				numHazOut.text = numHazards.ToString ();
			}
			if (numHazards > 0) {
				alert.effectColor = Color.red;
			} else {
				alert.effectColor = Color.black;
			}
		}
	}
}
