using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFightController : MonoBehaviour {
	Animator anim;
	public GameObject gameManager;
	List<Move> auxMoves;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
	    auxMoves = gameManager.GetComponent<MovesList> ().moves;
	}

	void Update(){
		Commands (Input.inputString);
	}

	void Commands (string input){
		if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5") {
			MakeMove (input);
		}
	}

	void MakeMove(string input){
		int moveIdx = int.Parse (input) - 1;
		if (auxMoves [moveIdx].Available) {
			Move (auxMoves[moveIdx].AnimName);
		}
	}


	public void Move(string triggerName){
		anim.SetTrigger (triggerName);
	}

}
