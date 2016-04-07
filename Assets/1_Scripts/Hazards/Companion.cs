using UnityEngine;
using System.Collections;

public class Companion : Bloboid {

	private float healthAlter = 20f;

	public Companion(){
		changeBaseHealth (healthAlter);
		addOtherActions ("Quietly judge you.");
	}
}
