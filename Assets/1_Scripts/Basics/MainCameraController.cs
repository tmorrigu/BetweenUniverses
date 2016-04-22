using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Border
{
	public float Top, Left;
	public float Base, Right;
}

public class MainCameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	public Border outline;

	//Update this with data about screen size - variable. Detect screen?

	void Awake(){
		if (!player) {
			GameObject[] temp = FindObjectsOfType<GameObject> ();
			foreach (GameObject item in temp) {
				if (item.CompareTag ("Player")) {
					player = item;
				}
			}
		}
	}

	void Start () {
		if (player == null) {
			Debug.Log ("Player Null");
			GameObject[] objects;
			objects = FindObjectsOfType (typeof(GameObject)) as GameObject[];
			for (int i = 0; i < objects.Length; i++) {
				if (objects [i].CompareTag ("Player")) {
					player = objects [i];
				}
			}
		}
		offset = new Vector3((transform.position.x - player.transform.position.x),(transform.position.y - player.transform.position.y),(transform.position.z - player.transform.position.z));
		outline = new Border();
		outline.Top = 2.43f;
		outline.Right = 0.1f;
		outline.Base = -18.5f;
		outline.Left = -20.3f;
	}
	
	void LateUpdate () {
		transform.position = player.transform.position + offset;
		/*
		if (transform.position.x > outline.Right) {
			transform.position = new Vector3(outline.Right, transform.position.y, transform.position.z);
		}
		if (transform.position.z < outline.Base) {
			transform.position = new Vector3(transform.position.x, transform.position.y, outline.Base);
		}
		if (transform.position.x < outline.Left) {
			transform.position = new Vector3(outline.Left, transform.position.y, transform.position.z);
		}
		if (transform.position.z > outline.Top) {
			transform.position = new Vector3(transform.position.x, transform.position.y, outline.Top);
		}
		*/
	}
}
