using UnityEngine;
using System.Collections;

public class Zwerok : Humanoid {

	private float healthAlter = 10f;

	public Zwerok(){
		changeBaseHealth (healthAlter);
		addOtherActions ("Charge Weapon");
	}
}
