using UnityEngine;
using System.Collections;

public class Energoid : Hazard {

	private int def = 5;
	private int agro = 1;
	private int str = 3;
	private int fear = 1;
	private float baseHealth = 40f;

	public Energoid(){
		canCommunicate = true;
		setHealth (baseHealth);
		setStats (def, agro, str, fear);
		setOtherActions ();
		addOtherActions ("Bzzip Whoosh");
	}

	protected void changeBaseHealth(float x){
		baseHealth += x;
		setHealth (baseHealth);
	}
}
