using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTester : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.D)){
			PlayerHealth.PlayerHealthChange (-1);
		}
		if(Input.GetKeyDown(KeyCode.F)){
			PlayerHealth.PlayerHealthChange (1);
		}		
	}
}
