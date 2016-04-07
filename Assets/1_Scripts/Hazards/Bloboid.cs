using UnityEngine;
using System.Collections;

public class Bloboid : Hazard {

	private int def = 1;
	private int agro = 2;
	private int str = 2;
	private int fear = 5;
	private float baseHealth = 40f;

	public Bloboid(){
		canCommunicate = true;
		setHealth (baseHealth);
		setStats (def, agro, str, fear);
		setOtherActions ();
		addOtherActions ("Gesture Animatedly");
	}

	protected void changeBaseHealth(float x){
		baseHealth += x;
		setHealth (baseHealth);
	}
}
