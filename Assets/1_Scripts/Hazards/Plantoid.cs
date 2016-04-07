using UnityEngine;
using System.Collections;

public class Plantoid : Hazard {

	private int def = 2;
	private int agro = 4;
	private int str = 3;
	private int fear = 1;
	private float baseHealth = 60f;

	public Plantoid(){
		canCommunicate = false;
		setHealth (baseHealth);
		setStats (def, agro, str, fear);
		setOtherActions ();
		addOtherActions ("Wave Vines");
	}

	protected void changeBaseHealth(float x){
		baseHealth += x;
		setHealth (baseHealth);
	}
}
