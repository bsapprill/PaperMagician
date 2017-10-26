using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*NOTES:
 *Enum will change between pickup types to refect desired behavior in-game
 *Still need to get a delegate set up for sending pickup behavior to the player character
 *The name of the player object is required to detect the collision
*/
public class Pickup : MonoBehaviour {
	
	public enum PickupType {Health, Memory};
	public PickupType ThisPickupType;

	#region Health Pickup

	int healthIncrease = 1;

	#endregion

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Player"){

			switch(ThisPickupType){
				case PickupType.Health:
					if(PlayerHealth.GetCurrentHealth()==16){
						break;
					}
					else{					
						PlayerHealth.PlayerHealthChange(healthIncrease);
						Destroy(this.gameObject);
						break;
					}
				case PickupType.Memory:
					break;
			}

		}
	}
}