using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
	public int health;
	public Slider healthSlider;
	Animator anim;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = health;
	}

	public void TakeDamage(int damage){
		health -= damage;
		MakeMove ();
	}

	public void MakeMove(){
		anim.SetTrigger ("punchMiyagi");
	}
}
