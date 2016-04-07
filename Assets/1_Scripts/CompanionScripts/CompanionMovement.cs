using UnityEngine;
using System.Collections;

public class CompanionMovement : MonoBehaviour {

	private GameObject player;
	private bool follow;
	private CompanionDialog cd;

//	private Rigidbody rb;

	//Experiment!
	private Vector3 a;
	private Vector3 b;
	private Vector3 c;
	private Vector3 d;
	private Vector3 e;
	private Vector3 f;
	private Vector3 g;
	private Vector3 h;
	private Vector3 i;
	private Vector3 j;
	private Vector3 k;
	private Vector3 l;


	void Start(){
		follow = false;
//		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			player = other.gameObject;
			cd = gameObject.GetComponent<CompanionDialog> ();
			cd.startRunning ();
		}
	}

	public void startRunning (){
		//This is where the companion is instructed to begin following the player
		follow = true;
	}

	void FixedUpdate(){
		if (follow) {
			if (l != Vector3.zero) {
				if (Vector3.Distance (player.transform.position, transform.position) > 0.5f) {
					transform.position = new Vector3 (a.x, transform.position.y, a.z);
//					rb.velocity = new Vector3 (a.x, transform.position.y, a.z);
				}
				a = b;
				b = c;
				c = d;
				d = e;
				e = f;
				f = g;
				g = h;
				h = i;
				i = j;
				j = k;
				k = l;
				l = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (k != Vector3.zero) {
				l = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (j != Vector3.zero) {
				k = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (i != Vector3.zero) {
				j = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (h != Vector3.zero) {
				i = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (g != Vector3.zero) {
				h = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (f != Vector3.zero) {
				g = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (e != Vector3.zero) {
				f = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (d != Vector3.zero) {
				e = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (c != Vector3.zero) {
				d = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (b != Vector3.zero) {
				c = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else if (a != Vector3.zero) {
				b = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			} else {
				a = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			}
		}
	}
}
