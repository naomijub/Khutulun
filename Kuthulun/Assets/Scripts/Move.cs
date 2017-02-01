using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour{

	public bool Available;
	public string Name;
	public string AnimName;
	public int Damage;

	public void SetAvailable(){
		Available = true;
	}
}
