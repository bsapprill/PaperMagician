using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour {

	public float moveSpeed;
	Vector3 moveDirection;

	public float rangeForAttacking;
	float distanceFromPlayer;

	int attackDamage = 1;

	Transform playersTransform;

	void Start () {
		playersTransform = GameObject.Find ("Player").transform;
	}

	void Update () {		
		SetDistanceFromPlayer ();
		if(rangeForAttacking < distanceFromPlayer){
			moveDirection = (playersTransform.position - transform.position).normalized;
			Debug.Log (moveDirection);
			transform.position += moveDirection * moveSpeed * Time.deltaTime;
		}
	}

	void SetDistanceFromPlayer(){
		distanceFromPlayer = Vector3.Distance (playersTransform.position, transform.position);
	}
}