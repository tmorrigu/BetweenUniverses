using UnityEngine;
using System.Collections;

public class Growth : Plantoid {

	private float healthAlter = 10f;

	public Growth(){
		changeBaseHealth (healthAlter);
		addOtherActions ("Pollen Burst");
	}
}
