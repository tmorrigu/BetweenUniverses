using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hazard : MonoBehaviour {

	//To set, fetch, track, and update health
	private float health;
	public void reduceHealth(float x){
		health -= x;
	}
	public float getHealth(){
		return health;
	}
	//Called by child classes during initialization
	protected void setHealth(float h){
		health = h;
	}

	//Each of these is on a scale of 1-5
	//Defense = chance deflect or reduce attack
	protected int defense;
	//Agression = chance attack versus other
	protected int agression;
	//Strength = chance attack will be more powerful
	protected int strength;
	//Fearfulness = chance run versus other
	protected int fearfulness;
	//canCommunicate indicates whether to include initialization
	protected bool canCommunicate;
	//Called by child classes during initialization
	protected void setStats(int d, int a, int s, int f){
		defense = d;
		agression = a;
		strength = s;
		fearfulness = f;
	}
	public int getDefense(){
		return defense;
	}
	public int getAgression(){
		return agression;
	}
	public int getStrength(){
		return strength;
	}
	public int getFearfulness(){
		return fearfulness;
	}
	public bool getCanCommunicate(){
		return canCommunicate;
	}

	//Stores other actions possible besides attack and run
	private List<string> otherActions;
	//Called by child class during initialization
	protected void setOtherActions(){
		otherActions = new List<string> ();
	}
	protected void addOtherActions(string next){
		otherActions.Add (next);
	}
	public List<string> getOtherActions(){
		return otherActions;
	}
}
