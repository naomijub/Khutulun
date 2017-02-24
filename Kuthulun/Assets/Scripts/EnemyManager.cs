using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour {
	public int health;
	public Slider healthSlider;
	public List<Move> auxMoves;
	public GameObject player;
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
		MakeMove ();
	}

	public void TakeDamage(int damage){
		health -= damage;
		CheckHealth ();
	}

	public void CheckHealth(){
		if (health <= 0) {
			StartCoroutine (DecideMove (2.5f));
			SceneManager.LoadScene (0);
		}
	}

	public void MakeMove(){
		if (Random.Range (0f, 10f) > 9.5f) {
			int moveIdx = (int)Random.Range (0f, auxMoves.Count); 
			GiveDamage (moveIdx);
			MakeMoveAnim (auxMoves [moveIdx].AnimName);
			StartCoroutine (DecideMove (3.0f));
		}
	}

	public void GiveDamage(int moveIdx){
		player.GetComponent<PlayerManager> ().TakeDamage (auxMoves [moveIdx].Damage);
	}

	public void MakeMoveAnim(string moveName){
		anim.SetTrigger (moveName);
	}

	IEnumerator DecideMove(float time)
	{
		yield return new WaitForSeconds (time);
	}
}
