using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EnemyManager : MonoBehaviour {
	public int health;
	public Slider healthSlider;
	public List<Move> auxMoves;
	public GameObject player;
	public Canvas speech;
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
		int actualDamage = damage * (int)Mathf.Sqrt(GameManagerScr.Instance.strength * GameManagerScr.Instance.speed) / (101 - GameManagerScr.Instance.exp);
		if (actualDamage <= 1) {
			speechControl(true);
			Debug.Log ("Speech should be here");
		} else {
			speechControl(false);		
		}
		health -= actualDamage;
		CheckHealth ();
		StartCoroutine_Auto (DecideMove (1.4f)); 
	}

	public void CheckHealth(){
		if (health <= 0) {
			StartCoroutine (DecideMove (2.5f));
			GameManagerScr.Instance.exp += 5;
			SceneManager.LoadScene (0);
		}
	}

	public void MakeMove(){
		int moveIdx = (int)UnityEngine.Random.Range (0f, auxMoves.Count); 
		GiveDamage (moveIdx);
		MakeMoveAnim (auxMoves [moveIdx].AnimName);
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
		Debug.Log ("Enemy enabled");
		MakeMove ();
		speechControl(false);
	}

	void speechControl(bool isEnable)
	{
		if (speech != null)
			{
				speech.enabled = isEnable;
			}
	}
}
