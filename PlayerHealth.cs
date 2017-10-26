﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*NOTE:
 *Can player pickup a health pickup at full health? What happens to the pickup? 
*/
public class PlayerHealth : MonoBehaviour {

	//These start at 16 every time
	static int playerHealthCurrent = 16;
	static int playerHealthMax = 16;

	static bool healthIsMaxed = true;

	#region Events

	public delegate void PlayerHealthEvent(int change);
	public static event PlayerHealthEvent HealthChange;

	//The change in health will always result in the correct change, whether positive or negative
	public static void PlayerHealthChange (int healthChange){		
		playerHealthCurrent += healthChange;
		playerHealthCurrent = Mathf.Clamp(playerHealthCurrent, 0, playerHealthMax);

		if(playerHealthCurrent == 16){
			if(!healthIsMaxed){				
				HealthChange (healthChange);
				healthIsMaxed = true;
			}
		}
		else if(playerHealthCurrent != 0){
			HealthChange (healthChange);
			healthIsMaxed = false;
		}
		else{
			
			//Need an else for when the player is at zero health
		}
	}

	#endregion

}