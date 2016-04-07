using UnityEngine;
using System.Collections;

public class Eoop : Mechanoid {

	private float healthAlter = 0f;

	public Eoop(){
		changeBaseHealth (healthAlter);
		addOtherActions ("Zap!");
	}
}
