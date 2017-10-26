using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*NOTES:
 *Enum will change between pickup types to refect desired behavior in-game
 *Still need to get a delegate set up for sending pickup behavior to the player character
 *The name of the player object is required to detect the collision
*/
public class Pickup : MonoBehaviour {
	
	public enum PickupType {Health};
	public PickupType ThisPickupType;

	#region Health Pickup

	int healthIncrease = 1;

	#endregion

	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Player"){

			switch(ThisPickupType){
				case PickupType.Health:
				
				PlayerHealth.PlayerHealthChange(healthIncrease);//This calls a static function
				break;
			}

			Destroy(this.gameObject);
		}
	}
}