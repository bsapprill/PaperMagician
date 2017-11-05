using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun: MonoBehaviour{
	public static bool playerIsStunned;
	public static float stunTimer;
	public static float stunDuration;

	void Update(){
		if(playerIsStunned){
			stunTimer += Time.deltaTime;
			if(stunTimer > stunDuration){
				stunTimer = 0f;
				playerIsStunned = false;
			}
		}
	}
}