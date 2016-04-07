using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : Hazard {

	private int def = 2;
	private int agro = 3;
	private int str = 2;
	private int fear = 3;
	private float baseHealth = 50f;

	public Humanoid(){
		canCommunicate = true;
		setHealth (baseHealth);
		setStats (def, agro, str, fear);
		setOtherActions ();
		addOtherActions ("Yell Loudly");
	}

	protected void changeBaseHealth(float x){
		baseHealth += x;
		setHealth (baseHealth);
	}
}
