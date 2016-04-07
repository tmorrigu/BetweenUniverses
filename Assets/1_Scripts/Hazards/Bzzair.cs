using UnityEngine;
using System.Collections;

public class Bzzair : Insectoid {

	private float healthAlter = 5f;

	public Bzzair(){
		changeBaseHealth (healthAlter);
		addOtherActions ("Bzzzzzzz...");
	}
}
