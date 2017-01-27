using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovesList : MonoBehaviour {
	public List<Move> moves;

	void Awake(){
	}

	public int FindMove(string name){
		for (int i = 0; i < moves.Count; i++) {
			if (moves [i].Name.ToLower() == name.ToLower()) {
				return i;
			}	
		}
		return -1;
	}

	public void MakeAvailable(string name){
		int idx = FindMove (name);
		moves [idx].SetAvailable ();
	}

	public IList<string> ListAllMoves(){
		IList<string> moveNames = new List<string> ();
		for (int i = 0; i < moves.Count; i++) {
			if (moves [i].Available) {
				moveNames.Add (moves [i].Name);
			}
		}
		return moveNames;
	}


}
