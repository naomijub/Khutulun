using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public bool Available { get; set;}
	public string Name { get; set;}

	public Move(bool availability, string name){
		this.Name = name;
		Available = availability;
	}

	public void SetAvailable(){
		Available = true;
	}
}
