using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
	//Removes the necessary heart piece from the necessary heart when the player loses health

	//These will only change if the game is re-balanced
	const int totalHealthHearts = 4;
	const int totalPiecesPerHeart = 4;

	int currentHeartPieceElement;
	GameObject[] heartPieceObjs = new GameObject[totalHealthHearts * totalPiecesPerHeart];

	void Start(){
		for (int a = 0; a < totalHealthHearts; a++) {

			//This keeps track of where the new heart pieces are entered into the heartPieceObjs array
			int piecesArrayIterator = a * totalPiecesPerHeart;

			GameObject localHealthHeart = transform.Find ("HealthHeart"+a.ToString()).gameObject;

			for (int b = 0; b < totalPiecesPerHeart; b++) {
				heartPieceObjs[piecesArrayIterator + b] = localHealthHeart.transform.Find ("HeartPiece" + b.ToString()).gameObject;
			}
		}
		//By this point, each individual heart piece object is in the heartPieceObjs array

		currentHeartPieceElement = heartPieceObjs.Length - 1;//Initializes using number of heart pieces
	}

	//These are used for subscribing to messages for the most part
	void OnEnable (){
		PlayerHealth.HealthChange += UpdateHeartPieces;
		PlayerHealth.PlayerHealthZero += ResetHeartPieces;
	}

	void OnDisable (){
		PlayerHealth.HealthChange -= UpdateHeartPieces;
		PlayerHealth.PlayerHealthZero -= ResetHeartPieces;
	}

	#region Function

	void UpdateHeartPieces(int value){
		if(value > 0){			
			for (int i = 0; i < value; i++){				
				//This will not go over the max array size b/c the delegate is not called if the player is at full health
				if (currentHeartPieceElement < 15) {
					currentHeartPieceElement++;
					heartPieceObjs [currentHeartPieceElement].SetActive (true);
				}
			}
		}
		else{
			for (int i = 0; i < Mathf.Abs(value); i++) {				
				heartPieceObjs [currentHeartPieceElement].SetActive (false);
				currentHeartPieceElement--;
			}
		}			
	}

	void ResetHeartPieces(){
		for (int a = 0; a < heartPieceObjs.Length; a++) {
			heartPieceObjs[a].gameObject.SetActive (true);
		}
	}

	#endregion


	/*
	 * These may be useful down the line for expanding the heart bar, but for now a	 simpler solution is
	 * to just get all of the individual heart piece objects, and just control them as we go
	HealthHeart[] healthHearts = new HealthHeart[4];

	class HealthHeart{
		GameObject healthHeartObj;
		GameObject[] heartPieceObjs = new GameObject[4];

		public HealthHeart(GameObject obj, GameObject[] pieces){
			healthHeartObj = obj;
			heartPieceObjs = pieces;
		}
	}
	*/
}