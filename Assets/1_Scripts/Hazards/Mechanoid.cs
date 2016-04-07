using UnityEngine;
using System.Collections;

public class Mechanoid : Hazard {

	private int def = 3;
	private int agro = 1;
	private int str = 5;
	private int fear = 1;
	private float baseHealth = 70f;

	public Mechanoid(){
		canCommunicate = true;
		setHealth (baseHealth);
		setStats (def, agro, str, fear);
		setOtherActions ();
		addOtherActions ("Beep Boop");
	}

	protected void changeBaseHealth(float x){
		baseHealth += x;
		setHealth (baseHealth);
	}
}
