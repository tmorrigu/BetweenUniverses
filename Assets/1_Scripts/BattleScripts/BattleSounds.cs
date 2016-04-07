using UnityEngine;
using System.Collections;

public class BattleSounds : MonoBehaviour {

	public AudioClip pAttack;
	public AudioClip mAttack;
	public AudioClip pRun;
	public AudioClip mRun;

	private AudioSource source;

	void Awake () {

		source = GetComponent<AudioSource>();
	}

	public void playerAttack(){
		source.PlayOneShot (pAttack);
	}

	public void monsterAttack(){
		source.PlayOneShot (mAttack);
	}

	public void playerRun(){
		source.PlayOneShot (pRun);
	}

	public void monsterRun(){
		source.PlayOneShot (mRun);
	}
}
