using UnityEngine;
using System.Collections;

public class PlayerFightController : MonoBehaviour {
	Animator anim;


	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
	}

	void Update(){
		KeyCode key = Input.GetKey ();
	}


	public void Kick(){
		anim.SetTrigger ("kick");
	}

	public void Kick100(){
		anim.SetTrigger ("100Kick");
	}

	public void Elbow(){
		anim.SetTrigger ("elbow");
	}

	public void Punch(){
		anim.SetTrigger ("punch");
	}

	public void WingChun(){
		anim.SetTrigger ("wingChun");
	}

}
