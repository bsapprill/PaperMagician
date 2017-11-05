using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripCeiling : MonoBehaviour {

	#region Variables

	public GameObject dripPrefab;

	public float timeBetweenDrips;
	float dripTimer = 0f;

	Vector3 dripSpawn;//Where the drips instantiate
	
	#endregion

	void Start(){
		dripSpawn = transform.position;
	}

	void Update(){
		dripTimer += Time.deltaTime;

		if(dripTimer > timeBetweenDrips){
			dripTimer = 0f;
			Instantiate (dripPrefab, dripSpawn, Quaternion.identity);
		}
	}

	#region Functions

	#endregion
}