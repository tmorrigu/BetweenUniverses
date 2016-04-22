using UnityEngine;
using System.Collections;

public class ArrowControls : MonoBehaviour {

	[HideInInspector]
	public float horiz;
	[HideInInspector]
	public float vert;
	public int gravity = 5;
	[HideInInspector]
	public Vector2 ArrowInput;
	const float MULTIPLE = 0.01f; 
	const float SPEED = 1.0f;
	private bool held = false;

	// Update is called once per frame
	void FixedUpdate () {
		if (!held) {
			if (horiz != 0) {
				if (horiz > 0) {
					horiz -= (MULTIPLE * gravity);
				} else {
					horiz += (MULTIPLE * gravity);
				}
			}
			if (vert != 0) {
				if (vert > 0) {
					vert -= (MULTIPLE * gravity);
				} else {
					vert += (MULTIPLE * gravity);
				}
			}
			ArrowInput = new Vector2 (horiz, vert);
		}
	}

	public void Left(){
		horiz = -SPEED;
		ArrowInput = new Vector2 (horiz, vert);
		held = true;
	}
	public void Right(){
		horiz = SPEED;
		ArrowInput = new Vector2 (horiz, vert);
		held = true;
	}
	public void Up(){
		vert = SPEED;
		ArrowInput = new Vector2 (horiz, vert);
		held = true;
	}
	public void Down(){
		vert = -SPEED;
		ArrowInput = new Vector2 (horiz, vert);
		held = true;
	}
	public void Release(){
		held = false;
	}
}
