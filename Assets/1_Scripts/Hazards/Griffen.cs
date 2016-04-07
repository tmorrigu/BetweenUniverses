using UnityEngine;
using System.Collections;

public class Griffen : Beastoid {

	private float healthAlter = 0f;

	public Griffen(){
		changeBaseHealth (healthAlter);
		addOtherActions ("Flap Wings");
	}
}
