using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowKnight : MonoBehaviour {

	public float moveSpeed;
	Vector3 moveDirection;

	public float lungeSpeed;

	float distanceFromPlayer;

	int attackDamage = 5;

	public float swingRadius;
	public float timeTillSwingAttack;
	float swingAttackTimer = 0f;

	public float timeTillLungeAttack;
	float lungeAttackTimer = 0f;

	int shockwaveDamage = 3;
	public float timeTillShockwaveAttack;
	float shockwaveAttackTimer = 0f;

	Transform playersTransform;

	enum KnightAI {Assess, Swing, Lunge, Shockwave};
	KnightAI AIState;

	void Start () {
		playersTransform = GameObject.Find ("Player").transform;
	}

	void Update(){
		switch(AIState){
		case KnightAI.Assess:
			SetDistanceFromPlayer ();

			lungeAttackTimer += Time.deltaTime;
			shockwaveAttackTimer += Time.deltaTime;

			if(distanceFromPlayer < swingRadius){
				AIState = KnightAI.Swing;
			}
			else if(lungeAttackTimer > timeTillLungeAttack){
				lungeAttackTimer = 0f;
				AIState = KnightAI.Lunge;
			}
			else if(shockwaveAttackTimer > timeTillSwingAttack){
				shockwaveAttackTimer = 0f;
				AIState = KnightAI.Shockwave;
			}
			break;

		case KnightAI.Swing:
			SetDistanceFromPlayer ();
			if(distanceFromPlayer > swingRadius){
				AIState = KnightAI.Assess;
				swingAttackTimer = 0f;
			}
			else{
				swingAttackTimer += Time.deltaTime;
				if(swingAttackTimer > timeTillSwingAttack){
					swingAttackTimer = 0f;
					PlayerHealth.PlayerHealthChange (-attackDamage);
				}
			}
			break;
		
		case KnightAI.Lunge:
			break;
		
		case KnightAI.Shockwave:
			break;
		}
	}

	void SetDistanceFromPlayer(){
		distanceFromPlayer = Vector3.Distance (playersTransform.position, transform.position);
	}
}