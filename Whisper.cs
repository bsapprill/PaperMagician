using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whisper : MonoBehaviour {

	public float moveSpeed;
	Vector3 moveDirection;
	float flipDirectionTimer;
	public float directionDuration;//This is how long the object will travel in the same direction

	public float stunRadius;
	public float stunDuration;
	float stunTimer = 0f;
	float inStunRadiusTimer = 0f;
	public float timeTillStunOccurs;
	float distanceFromPlayer;

	int attackDamage = 2;

	public float transparencyDuration;
	float transparencyTimer;
	Renderer whisperRenderer;

	Transform playersTransform;

	bool playerIsStunned = false;
	bool whisperIsTransparent = false;

	//Whisper moves back and forth
	//Whisper can stun the player
	//Whisper can damage the player
	//Whisper can swap between transparency
	//Whisper only attacks when the player is stunned

	void Start(){
		moveDirection = Vector3.left;
		playersTransform = GameObject.Find ("Player").transform;
		whisperRenderer = GetComponent<Renderer> ();
	}

	void Update(){
		transform.position += moveDirection * moveSpeed * Time.deltaTime;
		flipDirectionTimer += Time.deltaTime;

		if(flipDirectionTimer > directionDuration){
			moveDirection.x *= -1f;//Flips the x direction
			flipDirectionTimer = 0f;
		}

		SetDistanceFromPlayer ();

		if(!playerIsStunned){			
			if (distanceFromPlayer <= stunRadius) {
				inStunRadiusTimer += Time.deltaTime;
				if (inStunRadiusTimer > timeTillStunOccurs) {
					playerIsStunned = true;
					PlayerHealth.PlayerHealthChange (-attackDamage);//Health is changed by the value passed in
					inStunRadiusTimer = 0f;
					//Player needs to lose control of movement at this point; need to send message to player
					whisperIsTransparent = true;
					SetWhisperTransparency (whisperIsTransparent);
				}
			}
			else if(distanceFromPlayer > stunRadius){
				inStunRadiusTimer = 0f;
			}
		}
		else{
			stunTimer += Time.deltaTime;
			if(stunTimer > stunDuration){
				stunTimer = 0;
				playerIsStunned = false;
				//Player re-gains control of movement; need message to be sent to player
			}
		}

		if(whisperIsTransparent){
			transparencyTimer += Time.deltaTime;

			if(transparencyTimer > transparencyDuration){
				whisperIsTransparent = false;
				SetWhisperTransparency (whisperIsTransparent);
				transparencyTimer = 0f;
			}
		}
	}

	void SetDistanceFromPlayer(){
		distanceFromPlayer = Vector3.Distance (playersTransform.position, transform.position);
	}

	void SetWhisperTransparency(bool isTransparent){
		if(isTransparent){
			ChangeTransparency (-255);
		}
		else{
			ChangeTransparency (255);
		}
	}

	//Alpha value must be either positive or negative 255
	void ChangeTransparency(float alphaValue){
		whisperRenderer.material.color += new Color(0,0,0,alphaValue);
	}
}