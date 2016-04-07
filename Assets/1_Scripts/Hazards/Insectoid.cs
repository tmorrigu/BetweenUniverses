using UnityEngine;
using System.Collections;

public class Insectoid : Hazard {

	private int def = 4;
	private int agro = 2;
	private int str = 2;
	private int fear = 2;
	private float baseHealth = 60f;

	public Insectoid(){
		canCommunicate = false;
		setHealth (baseHealth);
		setStats (def, agro, str, fear);
		setOtherActions ();
		addOtherActions ("Chitter");
	}

	protected void changeBaseHealth(float x){
		baseHealth += x;
		setHealth (baseHealth);
	}
}
