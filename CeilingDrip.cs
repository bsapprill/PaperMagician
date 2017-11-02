using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingDrip : MonoBehaviour {
	public float fallingSpeed;
	public int dripDamage;

	void Update(){
		transform.position += fallingSpeed * Vector3.down * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			//Is negative to represent the health "change"
			PlayerHealth.PlayerHealthChange (-dripDamage);

			Destroy (this.gameObject);
		}
		else if(other.gameObject.layer == 8){
			Destroy (this.gameObject);
		}
	}
}