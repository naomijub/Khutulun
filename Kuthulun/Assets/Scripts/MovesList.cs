using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovesList : MonoBehaviour {
	public IList<Move> moves = new ArrayList ();

	void Awake(){
		moves.Add (new Move (true, "Punch"));
		moves.Add (new Move (true, "Kick"));
		moves.Add (new Move (false, "100 Kicks"));
		moves.Add (new Move (false, "Hiza (elbow)"));
		moves.Add (new Move (false, "Wing Chun Punches"));
	}

	public int FindMove(string name){
		for (int i = 0; i < moves.Count; i++) {
			if (moves [i].Name.ToLower() == name.ToLower()) {
				return i;
			}	
		}
	}

	public void MakeAvailable(string name){
		int idx = FindMove (name);
		moves [idx].SetAvailable ();
	}

}
