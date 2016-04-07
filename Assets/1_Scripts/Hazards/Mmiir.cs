using UnityEngine;
using System.Collections;

public class Mmiir : Energoid {

	private float healthAlter = -5f;

	public Mmiir(){
		changeBaseHealth (healthAlter);
		addOtherActions ("Glowwww....");
	}
}
