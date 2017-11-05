using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour {

	public float moveSpeed;
	Vector3 moveDirection;

	public float rangeForAttacking;
	float distanceFromPlayer;
	float xDifference;
	bool attackFromRight;

	//This is how tight the crow arc is.
	//A lower value creates a larger arc?
	public float rotationRate;

	int attackDamage = 1;

	Transform playersTransform;

	enum AttackState {Idle, Attacking};
	AttackState crowState;

	void Start () {
		playersTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {		
		SetDistanceFromPlayer ();

		switch(crowState){
		case AttackState.Idle:
			if(rangeForAttacking < distanceFromPlayer){
				xDifference = transform.position.x - playersTransform.position.x;
				if(xDifference > 0){
					attackFromRight = true;
				}
				else{
					attackFromRight = false;
				}
				crowState = AttackState.Attacking;
			}
			break;
		case AttackState.Attacking:
			CalculateMoveDirection ();
			transform.position += moveDirection * moveSpeed * Time.deltaTime;
			break;
		}
	}

	void SetDistanceFromPlayer(){
		distanceFromPlayer = Vector3.Distance (playersTransform.position, transform.position);
	}

	void CalculateMoveDirection(){
		
		moveDirection = Vector3.down;

		if(attackFromRight){
			if (moveDirection.x >= 0f) {
				moveDirection.x += rotationRate;
			}
			moveDirection.y += rotationRate;
		}
		else{
			moveDirection.x += rotationRate;
			moveDirection.y -= rotationRate;
		}
	}
}