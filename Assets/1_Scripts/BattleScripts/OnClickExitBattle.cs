using UnityEngine;
using System.Collections;

public class OnClickExitBattle : MonoBehaviour {

	void Update(){
		if (Input.GetMouseButton (0)) {
			GameManager.instance.endBattle ();
		}
	}
}
