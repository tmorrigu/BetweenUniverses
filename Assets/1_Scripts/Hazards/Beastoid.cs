using UnityEngine;
using System.Collections;

public class Beastoid : Hazard {

	private int def = 2;
	private int agro = 3;
	private int str = 3;
	private int fear = 2;
	private float baseHealth = 60f;

	public Beastoid(){
		canCommunicate = false;
		setHealth (baseHealth);
		setStats (def, agro, str, fear);
		setOtherActions ();
		addOtherActions ("Growl");
	}

	protected void changeBaseHealth(float x){
		baseHealth += x;
		setHealth (baseHealth);
	}
}
