using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	public AudioClip step1;
	public AudioClip step2;
	public AudioClip step3;

	private float selection;
	private AudioSource source;
	private int timer = 0;

	void Awake () {

		source = GetComponent<AudioSource>();
	}

	void FixedUpdate() {
		//25 is an arbitrary number that made the steps sound good to me
		if ((Input.anyKey)&(timer>25)){
			selection = Random.Range (0.1f, 2.9f);
			if(selection<1){
				source.PlayOneShot (step1, 0.15f);
			}else if (selection <2){
				source.PlayOneShot (step2, 0.15f);
			}else if(selection<3){
				source.PlayOneShot (step3, 0.15f);
			}
			timer = 0;
		}
		timer++;
	}
}
